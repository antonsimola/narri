using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        private string CurrentString;
        private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
        private Queue<string> Words = new Queue<string>();
        public void Start()
        {
            var r = new Random(1);
            var i = r.NextInt(0, JokeHolder.Jokes.Count);
            var joke  = JokeHolder.Jokes[i];
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
                            return;
                        }
                        
                        if (keyCode == KeyCode.Quote)
                        {
                            CurrentString += "ä";
                            return;
                        }
                        
                        if (keyCode == KeyCode.LeftBracket)
                        {
                            CurrentString += "å";
                            return;
                        }
                        if (keyCode == KeyCode.Space)
                        {
                            ValidateCurrent();
                            return;
                        }

                        if (keyCode == KeyCode.Backspace)
                        {
                            CurrentString = CurrentString.Substring(0, CurrentString.Length - 1);
                            return;
                        }
                        
                        if (keyCode.ToString().Length > 1) break;
                        
                        typedKey = keyCode;
                        CurrentString += typedKey.ToString().ToLower();
                        break;
                    }
                }
                Debug.Log(CurrentString);
            }
            
             
        }

        private void ValidateCurrent()
        {
            Debug.Log(CurrentString);
            CurrentString = "";
        }
    }
}