using System;



namespace ProjectGeniusRedone
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string[] questions = ReadFromQuestionsFile(sCurrentDirectory);
            string[] answers = ReadFromAnswersFile(sCurrentDirectory);

            System.Collections.Generic.IDictionary<string, string> questionsAndAnswers = new System.Collections.Generic.Dictionary<string, string>();

            if (questions.Length == 0 || answers.Length == 0)
            {
                //the files are empty
            }
            else
            {
                //make a dictionary using the questions and answers
                for (int i = 0; i < questions.Length; i++)
                {
                    //questions and answers should be the same length, so their sizes are interchangable
                    questionsAndAnswers.Add(questions[i], answers[i]);
                    
                }
            }

            string userInput = " ";
            string temp = " ";

            while (userInput != "DONE")
            {
                Console.WriteLine("Ask a question and we'll see if we have the answer. Or enter 'DONE' to quit.");
                userInput = Console.ReadLine();
                if (userInput == "DONE")
                {
                    break;
                }

                
                if (questionsAndAnswers.ContainsKey(userInput))
                {
                    Console.WriteLine("The answer is: " + questionsAndAnswers[userInput]);
                }
                else
                {
                    Console.WriteLine("We don't seem to have an answer for that one... could you provide one?");
                    temp = Console.ReadLine();
                    questionsAndAnswers.Add(userInput, temp);
                }

            }

            //write out the dictionary to the appropriate files, incorporating any newly added questions and answers to the database
            System.Collections.Generic.ICollection<string> keys = questionsAndAnswers.Keys;
            System.Collections.Generic.ICollection<string> values = questionsAndAnswers.Values;

            string[] stringKeys = new string[keys.Count];
            string[] stringValues = new string[values.Count];

            
            keys.CopyTo(stringKeys, 0);
            values.CopyTo(stringValues, 0);

            WriteToQuestionsFile(sCurrentDirectory, stringKeys);
            WriteToAnswersFile(sCurrentDirectory, stringValues);


        }

        private static void WriteToQuestionsFile(string sCurrentDirectory, string[] keys)
        {
            
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../Questions.txt");
            string sFilePath = System.IO.Path.GetFullPath(sFile);
            System.IO.File.Create(sFilePath).Close();   //wipe the file so that I can write the new contents to it
            System.IO.File.AppendAllLines(sFilePath, keys);
            
        }

        private static void WriteToAnswersFile(string sCurrentDirectory, string[] values)
        {
            
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../Answers.txt");
            string sFilePath = System.IO.Path.GetFullPath(sFile);
            System.IO.File.Create(sFilePath).Close();   //wipe the file so that I can write the new contents to it
            System.IO.File.AppendAllLines(sFilePath, values);

        }

        private static string[] ReadFromQuestionsFile(string sCurrentDirectory)
        {
            

           
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../Questions.txt");
            string sFilePath = System.IO.Path.GetFullPath(sFile);
            string[] lines = System.IO.File.ReadAllLines(sFilePath);
            return lines;
        }

        private static string[] ReadFromAnswersFile(string sCurrentDirectory)
        {


            
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../Answers.txt");
            string sFilePath = System.IO.Path.GetFullPath(sFile);
            string[] lines = System.IO.File.ReadAllLines(sFilePath);
            return lines;
        }
    }
}
