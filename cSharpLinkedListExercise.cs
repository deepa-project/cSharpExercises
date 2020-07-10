using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//source of code: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
//objective: learn to navigate through linkedlist built in functions and create ones own functions too
//Object oriented learning: sometimes linkedlist package defined data type is used as inout arguments to funtions
//a variable declared as a linkedlistnode can access an entire linkedlist
//such a variable when declared inside a private funtion can still access the linkedlist which has been referred by the input argument linkedlist node
namespace cSharpExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the link list
            String[] words = { "The", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Display(sentence,"jumps");
          
            //Add the word 'today' to the beginning of the linkedlist 'sentence'
            sentence.AddFirst("today");
            Display(sentence,"Testing 1");
            Console.WriteLine("\n\nResuming main method\n\n");

            //Move the first node to the last node
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "test 2");
            Console.WriteLine("\n\nResuming main method\n\n");


            //Change the last node to yesterday
            sentence.RemoveLast();
            sentence.AddLast("Yesterday");
            Display(sentence, "Test 3");
            Console.WriteLine("\n\nResuming main method\n\n");



            //Move the last node to the first node
            LinkedListNode<string> mark2 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark2);
            Display(sentence, "test 4");
            Console.WriteLine("\n\nResuming main method\n\n");



            //Indicate last occurence of the word 'the'
            Console.WriteLine("I AM PASSING ONLY ONE LINKEDLIST NODE AND ONE STRING AS INPUT PARAMETERS TO THE FUNCTION INDICATENODE, THE LINKEDLIST NODE IS FROM THE\n LINKEDLIST --sentence--AS FOUND IN THE MAIN");
            LinkedListNode<string> current = sentence.FindLast("the");
            IndicateNode(current, "Test 5:The last occurence of the word 'the' in this sentence is :");
            Console.WriteLine("\n\nResuming main method\n\n");


            //Add 'lazy' and 'old' after the linkedlist node named 'current'
            sentence.AddAfter(current, "lazy");
            sentence.AddAfter(current, "old");
            IndicateNode(current," add 'lazy' and 'old' after 'the'-test 6");
            Console.WriteLine("\n\nResuming main method\n\n");



            //Indicate 'fox' node
            current = sentence.Find("fox");
            IndicateNode(current, "test 7:Indicate the fox node");

            //Add 'quick' and 'brown' before 'fox'
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "test 8");

            //Keep a reference to the current node 'fox'
            //And to the previous node in the list
            //Indicate the 'dog' node
             LinkedListNode<string> mark3 = current;
            LinkedListNode<string> mark3_previous = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current,"test 9");

            //below is original copy-paste to help debug errors
            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            //mark1 = current;
            // mark2 = current.Previous;
            //current = sentence.Find("dog");
            //  IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            //the add before node throws an invalid operation exception when 
            //a node is added to it that already exists

            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list");
            try
            {
                Console.WriteLine("we are in the try block");
                Console.WriteLine("The node we are going to add has been declared and used before and associated with the linkedlist -sentence-");
                sentence.AddBefore(current,mark1);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Message (0):", e.Message);
            }

           
            Console.WriteLine();


            //Remove the node referred by mark1
            //then add it before the node referred by current
            //indicate the node referred by current
            //in the original code, mark 1 was current (ref rest 9)
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "test 11: ");






            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();

        }
        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine("\n\nFROM MAIN FUNTION TO DISPLAY FUNCTION\n\n");
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\nDisplay method works!\n");
            Console.WriteLine("\n\n END OF DISPLAY FUNCTION\n\n");
            Console.WriteLine();            
        }

        private static void IndicateNode(LinkedListNode<string> x , string str2)
        {

            Console.WriteLine("\n\nINDICATE NODE FUNCTION BEGINS\n\n");
            Console.WriteLine($"This is the value passed as a string-second argument to the function IndicateNode :{str2}");

            Console.WriteLine($"This is the first of the two arguments in the function IndicateNode: {x.Value}");
            Console.WriteLine($"We are checking if {x.Value} is in the linkedlist using the command (x.List) {x.List}");
            if (x.List==null)
            {
               
                Console.WriteLine($"The {x.Value} is not in list");
                return;
            }

            Console.WriteLine($"We have passed out of the if condition that suggests that the {x.Value} is not in the list!");
            Console.WriteLine($"So the {x.Value} is definitely there in the list {x.List}");
            Console.WriteLine($"So we are creating a nw string using the string builder function to replicate the linkedlist strings \n and shows the occurence of the word {x.Value}last occured in brackets");
            Console.WriteLine($"The string {x.Value} to be found was passed on as a linkedlistnode argument");
            Console.WriteLine("We are going to convert the linkedlist to a string using the string builder function");
            Console.WriteLine($"Using the property linkedlistnode.pervious, we are going to assign a new linkedlistnode with the {x.Value} passed as\n linkedlistnode argument s linkedlistnode.previous property");

            StringBuilder str = new StringBuilder("(" +x.Value +  ")");
            Console.WriteLine("We do not directly refer to the linedlist --sentence--as we created in the main in this function here");
            Console.WriteLine("We play around with anoter linkedlist node which we create at random which is going to refer /n the linkedlist from the main");
            Console.WriteLine("SINCE WE EQUATE THE NEW VRIABLE LINKEDLIST NODE IN THE FUNCTION TO THAT PASSED AS ARGUMENT");
            Console.WriteLine("THIS NEWLY CREATED LINKEDLIST NODE IN THE FUNCTION CAN ALSO REFER THE SAME LINKEDLIST");
            Console.WriteLine("BASICALLY THE LINKEDLIST IS CREATED AS A GLOBAL VARIABLE AND CAN BE REFERENCED ANYWAYS");
            LinkedListNode<string> p = x.Previous;
            Console.WriteLine("Using the stringbuilder s insert property, we are inserting all the linkedlistnodes previous to the word to\n be found(which got passed on as linkedlistnode and is now a string");
            Console.WriteLine($"The new linkedlist node now has the value {p.Value}");
            //Console.WriteLine("We are entering a while loop to insert previous values of the linkedlist to the str");
            while(p!=null)
            {
                str.Insert(0,p.Value+ " ") ;
               // Console.WriteLine(str);
                p = p.Previous;
                //Console.WriteLine($"The new linkedlist node now has the value {p.Value}");
            }

            Console.WriteLine("Now we are out of the while loop");
            Console.WriteLine("We have so far succesfully built this part of the string");
            Console.WriteLine(str);
            //Console.WriteLine($"Outside the while loop the value of the linkedinnode pointing to the linkedlist was {p.Value}");
            
                x = x.Next;
                //deepa-modified code here as compilation threw null pointer exception
                if (x != null)
                {
                    Console.WriteLine($"Now it has the value {x.Value} after using the next property of linkedlistnode");
                Console.WriteLine("Now we are directly using the linkedlist node properties of the funtion argument");
                Console.WriteLine($"The value of the function argument which got passed in as linkedlist node is {x.Value}");
                Console.WriteLine("We are appending this to the string building that happened in the previous while loop using anohter while loop ");
                Console.WriteLine($"This time we are using going to traverse the linkedlistnode using linkedlistnode.next property of the passed on argument {x.Value}");
                Console.WriteLine("The second while loop begins now");
                while (x != null)
                {
                    str.Append(" " + x.Value);
                    Console.WriteLine(str);
                    x = x.Next;
                    //Console.WriteLine($"The new value to be added is now {x.Value}");
                }
            }

            Console.WriteLine("End of second while loop");
            Console.WriteLine(str);
            Console.WriteLine("\n\nINDICATE NODE FUNCTION ENDS\n\n");

            Console.WriteLine();




        }


    }
}
