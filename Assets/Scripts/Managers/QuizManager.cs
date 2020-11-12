using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private JSONContainer questions;
    private JSONContainer facts;

    private List<string> factsList;
    private List<string> questionsList;
    public List<string> aquiredFacts = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        TextAsset questionData = Resources.Load("Quiz/questions") as TextAsset;
        TextAsset factsData = Resources.Load("Quiz/facts") as TextAsset;
        questions = JsonUtility.FromJson<JSONContainer>(questionData.text);
        facts = JsonUtility.FromJson<JSONContainer>(factsData.text);

        factsList = facts.text.ToList();
        questionsList = facts.text.ToList();
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
    private string GetQuestion(int questionID)
    {
        return questionsList[questionID];
    }

    /// <summary>
    /// Returns a random fact from all possible facts
    /// </summary>
    /// <returns>A random question</returns>
    public string GetRandomFact()
    {
        return GetFact(Random.Range(0, factsList.Count));
    }

    /// <summary>
    /// Return a random question from the ones possible
    /// </summary>
    /// <returns>A random question</returns>
    public string GetRandomQuestion()
    {
        return GetQuestion(Random.Range(0, questionsList.Count));
    }

    /// <summary>
    /// Give the player a fact
    /// </summary>
    /// <param name="factID">Where in the list to give the fact</param>
    private void AquireFact(int factID)
    {
        string fact = GetFact(factID);
        factsList.RemoveAt(factID);
        aquiredFacts.Add(fact);
    }

    /// <summary>
    /// Give the player a random fact
    /// </summary>
    public void AquireRandomFact()
    {
        AquireFact(Random.Range(0, factsList.Count));
    }

    /// <summary>
    /// Get what facts the player has aquired
    /// </summary>
    /// <returns>A list of all facts the player has</returns>
    public List<string> GetAquiredFacts()
    {
        return aquiredFacts;
    }
}
