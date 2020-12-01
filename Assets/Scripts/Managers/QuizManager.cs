using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    [Tooltip("Reference to the GameManager")]
    public GameManager gameManager;

    [Tooltip("Refernce to the PlayerManager")]
    public PlayerManager playerManager;
    
    private QuestionContainer questions;
    private FactContainer facts;

    private string[] factsList;
    private List<QuestionInfo> questionsList;
    public string[] aquiredFacts;
    private List<int> factsLeft = new List<int>();
    
    [Tooltip("Reference to the UI Manager.")]
    public UIManager uiManager;

    [Tooltip("How long to pause/slow down the game for")]
    public float pauseTime;

    [Tooltip("How much to slow down the game. 0 to completly pause")]
    public float slowdownAmount;

    [Tooltip("The current question being asked")]
    public QuestionInfo currentQuestion;

    [Tooltip("How many questions to ask during the quiz")]
    public int maxQuestions;

    /// <summary>
    /// How many questions have been asked
    /// </summary>
    private int questionsAsked;

    /// <summary>
    /// How many facts the player has aquired
    /// </summary>
    private int factsCount = 0;
    
    [Tooltip("How many points a correct question is worth, if it does not revive")]
    public int quizPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset questionData = Resources.Load<TextAsset>("Quiz/questions");
        TextAsset factsData = Resources.Load<TextAsset>("Quiz/facts");
        questions = JsonUtility.FromJson<QuestionContainer>(questionData.text);
        facts = JsonUtility.FromJson<FactContainer>(factsData.text);

        factsList = facts.text.ToArray();
        questionsList = questions.Questions.ToList();
        Array.Resize(ref aquiredFacts, factsList.Length);
        for (int i = 0; i < factsList.Length; ++i)
        {
            factsLeft.Add(i);
        }
        //Debug.Log(questionsList.Count);
    }

    /// <summary>
    /// Returns a set fact
    /// </summary>
    /// <param name="factID">The location of the fact to get</param>
    /// <returns>A fact</returns>
    private string GetFact(int factID)
    {
        return factsList[factID];
    }

    /// <summary>
    /// Returns a set question
    /// </summary>
    /// <param name="questionID">The location of the question to get</param>
    /// <returns>A question</returns>
    private QuestionInfo GetQuestion(int questionID)
    {
        QuestionInfo question = questionsList[questionID];
        questionsList.RemoveAt(questionID);
        return question;
    }

    /// <summary>
    /// Returns a random fact from all possible facts
    /// </summary>
    /// <returns>A random question</returns>
    public string GetRandomFact()
    {
        return GetFact(Random.Range(0, factsList.Length));
    }

    /// <summary>
    /// Return a random question from the ones possible
    /// </summary>
    /// <returns>A random question</returns>
    public QuestionInfo GetRandomQuestion()
    {
        int rand = Random.Range(0, questionsList.Count);
        return GetQuestion(rand);
    }

    /// <summary>
    /// Give the player a fact. Pauses the game temporarily calls for the text to be shown on screen
    /// </summary>
    /// <param name="factID">Where in the list to give the fact</param>
    private IEnumerator AquireFact(int factID)
    {
        ++factsCount;
        string fact = GetFact(factID);
        aquiredFacts[factID] = fact;
        if (factsCount <= 1)
        {
            uiManager.ShowFact(fact);
            Time.timeScale = slowdownAmount;
        }
        else
        {
            StartCoroutine(uiManager.ShowNotification());
        }
        
        yield return new WaitForSecondsRealtime(pauseTime);
    }

    /// <summary>
    /// Give the player a random fact
    /// </summary>
    public void AquireRandomFact()
    {
        int factID = Random.Range(0, factsLeft.Count);
        StartCoroutine(AquireFact(factsLeft[factID]));
        factsLeft.RemoveAt(factID);
    }

    /// <summary>
    /// Get what facts the player has aquired
    /// </summary>
    /// <returns>An array of all facts the player has</returns>
    public string[] GetAquiredFacts()
    {
        return aquiredFacts;
    }

    public void StartQuiz()
    {
        uiManager.ShowQuiz();
        questionsAsked = 0;
        currentQuestion = NextQuestion();
        uiManager.UpdateQuiz(currentQuestion);
    }

    public QuestionInfo NextQuestion()
    {
        QuestionInfo question = GetRandomQuestion();
        uiManager.UpdateQuiz(question);
        return question;
    }
    
    public bool CheckAnswer(int answer)
    {
        return answer == currentQuestion.Correct;
    }

    public void QuestionSetup(bool isCorrect)
    {
        if (isCorrect)
        {
            gameManager.score += quizPoints;
            if (playerManager.timesRevived < playerManager.maxRevives)
            {
                uiManager.EndQuiz();
                playerManager.Revive();
            }
        }
        else
        {
            playerManager.timesRevived = playerManager.maxRevives;
        }
        
        ++questionsAsked;

        if (questionsAsked < maxQuestions)
        {
            currentQuestion = NextQuestion();
        }
        else
        {
            gameManager.EndGame();
        }
    }
}
