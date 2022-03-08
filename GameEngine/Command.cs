using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureProject.GameEngine
{
    public class Command
    {
        // Basic properties.
        public string ID { get; private set; }
        public Action commandActionNoParam;
        public Action<object> commandActionOneParam;
        public Action<object[]> commandActionMultiParam;
        public bool HasParams { get; private set; }
        public string[] paramDefinitions;
        public string paramDefinition;
        public object[] parameters;
        public object parameter;
        public int ParamCount { get; private set; }

        // No-Parameter command.
        public Command(string id, Action cmdAction)
        {
            commandActionNoParam = cmdAction;
            ID = id;

            HasParams = false;

            ParamCount = 0;
        }

        // Single-Parameter command.
        public Command(string id, Action<object> cmdAction, string paramDef = null)
        {
            commandActionOneParam = cmdAction;
            ID = id;

            HasParams = true;
            parameter = new object();
            paramDefinition = paramDef;

            ParamCount = 1;
        }

        // Multi-Parameter command.
        public Command(string id, Action<object[]> cmdAction, string[] paramDefs)
        {
            commandActionMultiParam = cmdAction;
            ID = id;

            HasParams = true;
            parameters = new object[paramDefs.Length];
            paramDefinitions = paramDefs;

            ParamCount = parameters.Length;
        }


        public void Run()
        {
            if (ParamCount < 1)
            {
                commandActionNoParam.Invoke();
            }
            else if (ParamCount == 1)
            {
                commandActionOneParam.Invoke(parameter);
            }
            else if (ParamCount > 1)
            {
                commandActionMultiParam.Invoke(parameters);
            }
        }
    }
}
