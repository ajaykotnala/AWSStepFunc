using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSServerless
{
    public class StepFunctionTasks
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public StepFunctionTasks()
        {
            //state step1 with with passing method to second(greeting)
            //step 1 will have retry mech
            //step 1 will have exception mech
            //step 1 will have log 

            //for custom error
            //{
            //    "CustomError": "Error from Api",
            //     "Comment": "Insert your JSON here"
            //}
        }


        public State FirstStep(State state, ILambdaContext context)
        {
            state.Message = "First Step start executing!";

            #region ErrorHandling
            //Error handling link https://docs.aws.amazon.com/step-functions/latest/dg/concepts-error-handling.html?shortFooter=true
            //https://docs.aws.amazon.com/step-functions/latest/dg/bp-lambda-serviceexception.html
            if (!string.IsNullOrEmpty(state.Name)) { state.Message += " " + state.Name; }
            else if (!string.IsNullOrEmpty(state.CustomError))
            { //this block will execute if any api error occur
                throw new CustomException("Custom Exception occur!");
            }
            else
            {
                //if api error or task itself fails and didnot catch in custom error then this block is the last defence line
                throw new Exception("ReservedTypeFallback some error in Task Execution!");
            }
            #endregion

            state.WaitInSeconds = 3;
            return state;
        }

        public State Greeting(State state, ILambdaContext context)
        {
            state.Message += ", Greeting start executing!";

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            // Tell Step Function to wait 5 seconds before calling 
            state.WaitInSeconds = 5;

            return state;
        }

        public State Salutations(State state, ILambdaContext context)
        {
            state.Message += ", Salutation start executing!"; ;

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            return state;
        }
    }
}
