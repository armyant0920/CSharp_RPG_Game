using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_TEST
{
    class Place
    {
        string Introduce;
        
        Dictionary<string, string> options;
        /// <summary>
        /// this method should be override by subclass
        /// </summary>
        void ShowMenu() {

            //foreach(){}
            Console.WriteLine("this is defaylt place");
        }

        void TakeAction(string input) { 
        //if input equals options code,do...
            
        
        }
    }
}
