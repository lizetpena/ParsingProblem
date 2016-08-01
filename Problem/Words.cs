using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public class Words
    {
        public string name;
       
        public List<Words> children;

        public Words(string n)
        {
            name = n;
            
            children = new List<Words>();
        }
    }
}
