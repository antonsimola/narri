using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
    public class WordSpawnerScript : MonoBehaviour
    {
        [SerializeField] public float wordInterval = 30;
        [SerializeField] public float wordMoveSpeed = 5;

        public WordScript WordPrefab;
        public TMP_Text CompleteJoke;

        private string FullJoke;

        private string CurrentString = "";
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        private Queue<string> Words = new Queue<string>();
        private Queue<WordScript> WordObjs = new Queue<WordScript>();
        public static WordSpawnerScript instance;

        private List<WordScript> completedWords = new List<WordScript>();
        private List<WordScript> failedWords = new List<WordScript>();
        private int jokeIndex;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Start()
        {
            var r = new Random(1);
            jokeIndex = r.NextInt(0, Jokes.JokeList.Count);
            var joke = Jokes.JokeList[jokeIndex];
            var words = joke.Split(" ");
            var j = 0;
            foreach (var word in words)
            {
                var y = r.NextInt(0, 5);
                var cleanedWord = Regex.Replace(word, "[^A-Za-z0-9äö]", "").ToLowerInvariant();
                Words.Enqueue(cleanedWord);

                StartCoroutine(QueueWord(wordInterval, cleanedWord, y, j++));
            }

            UpdateFullJoke();
        }

        private IEnumerator QueueWord(float speed, string word, int y, int j)
        {
            yield return new WaitForSeconds(speed * j);
            var wordObj = Instantiate(WordPrefab, new Vector3(5, y * 0.32f), Quaternion.identity);
            wordObj.SetWord(word);
            wordObj.SetSpeed(wordMoveSpeed);
            WordObjs.Enqueue(wordObj);
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                KeyCode typedKey = KeyCode.Mouse6;
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        if (keyCode == KeyCode.Semicolon)
                        {
                            CurrentString += "ö";
                            break;
                        }

                        if (keyCode == KeyCode.Quote)
                        {
                            CurrentString += "ä";
                            break;
                        }

                        if (keyCode == KeyCode.LeftBracket)
                        {
                            CurrentString += "å";
                            break;
                        }

                        if (keyCode == KeyCode.Space)
                        {
                            ValidateCurrent();
                            return;
                        }

                        if (keyCode == KeyCode.Backspace)
                        {
                            CurrentString = CurrentString.Substring(0, CurrentString.Length - 1);
                            break;
                        }

                        if (keyCode.ToString().Length > 1) break;

                        typedKey = keyCode;
                        CurrentString += typedKey.ToString().ToLower();
                        break;
                    }
                }

                UpdateWord();
                Debug.Log(CurrentString);
            }
        }

        private void UpdateWord()
        {
            var words = WordObjs.Peek();
            words._cleanWord = CurrentString;
            words.SetWord(ConstructStyle());
        }

        private void UpdateFullJoke()
        {
            CompleteJoke.SetText(string.Join(" ", completedWords.Select(w => w._cleanWord)));
        }

        private string ConstructStyle()
        {
            var target = Words.Peek();
            var i = 0;
            var styled = "";
            foreach (var c in CurrentString)
            {
                if (i >= target.Length) continue;

                if (c != target[i])
                {
                    styled += $"<color=red>{c}</color>";
                }
                else
                {
                    styled += $"<color=green>{c}</color>";
                }

                i++;
            }

            styled += $"<color=#cfaf4c>{target.Substring(i)}</color>";

            return styled;
        }

        private void ValidateCurrent()
        {
            var word = Words.Dequeue();
            var wordObj = WordObjs.Dequeue();


            if (CurrentString != word)
            {
                wordObj.targetWord = word;
                Destroy(wordObj.gameObject);
                var obj = Instantiate(WordPrefab,
                    new Vector3(wordObj.transform.position.x, wordObj.transform.position.y),
                    Quaternion.identity);
                var replaceWord = GetAlternativeWord(wordObj);
                obj._cleanWord = replaceWord;
                obj.SetWord(replaceWord);
                completedWords.Add(obj);

                GameController.instance.FailWord();
            }
            else
            {
                completedWords.Add(wordObj);
            }

            CurrentString = "";
            UpdateWord();
        }

        public void OnWordHitWall(WordScript wordObj, GameObject o)
        {
            if (failedWords.Contains(wordObj))
            {
                //Destroy(o);
                //TODO spawn random word
                Debug.Log("Failed word " + wordObj._cleanWord);
            }
            else if (completedWords.Contains(wordObj))
            {
                Debug.Log("Completed word " + wordObj._cleanWord);
            }
            else
            {
                Debug.Log("Missed word " + wordObj._cleanWord);
                //User has not finished the word yet
            }

            UpdateFullJoke();
        }

        public string GetAlternativeWord(WordScript wordObj)
        {
            if (!Jokes.WordFailAlternatives[jokeIndex].ContainsKey(wordObj.targetWord))
            {
                return wordObj.targetWord;
            }

            return GetRandomFromList(Jokes.WordFailAlternatives[jokeIndex][wordObj.targetWord]);
        }

        public T GetRandomFromList<T>(IList<T> list)
        {
            var i = GameController.instance.Random.Next(0, list.Count);
            return list[i];
        }
    }
}