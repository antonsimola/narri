using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
    public class WordSpawnerScript: MonoBehaviour
    {
        [SerializeField] public float wordInterval = 30;
        [SerializeField] public float wordMoveSpeed = 5;

        public WordScript WordPrefab;

        private string FullJoke;

        private string CurrentString = "";
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        private Queue<string> Words = new Queue<string>();
        private Queue<WordScript> WordObjs = new Queue<WordScript>();
        public static WordSpawnerScript instance;

        private List<WordScript> completedWords = new List<WordScript>();
        private List<WordScript> failedWords = new List<WordScript>();

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
            var i = r.NextInt(0, Jokes.JokeList.Count);
            var joke  = Jokes.JokeList[i];
            var words = joke.Split(" ");
            var j = 0;
            foreach (var word in words)
            {
                var y = r.NextInt(0, 5);
                var cleanedWord = Regex.Replace(word, "[^A-Za-z0-9äö]", "").ToLowerInvariant();
                Words.Enqueue(cleanedWord);
                
                StartCoroutine(QueueWord(wordInterval, cleanedWord,y,  j++));
            }
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
                    if (Input.GetKeyDown(keyCode)) {
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

                var words = WordObjs.Peek();
                words._cleanWord = CurrentString;
                words.SetWord(ConstructStyle());
                Debug.Log(CurrentString);
            }
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

            styled += target.Substring(i);

            return styled;
        }

        private void ValidateCurrent()
        {
            var word = Words.Dequeue();
            var wordObj = WordObjs.Dequeue();
            
            
            if (CurrentString != word)
            {
                failedWords.Add(wordObj);
                GameController.instance.FailWord();
            }
            else
            {
                completedWords.Add(wordObj);
            }
            CurrentString = "";
        }

        public void OnWordHitWall(WordScript wordObj)
        {
            if (failedWords.Contains(wordObj))
            {
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
            
            
        }
        
    }
}