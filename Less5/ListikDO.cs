using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Less5
{
    internal class ToDo
    {
        private static string[] title;
        private static string[] isDone;

        public string[] Title
        {
            get => title;
            set => title = value;
        }

        public string[] IsDone
        {
            get => isDone;
            set => isDone = value;
        }

    }
}
