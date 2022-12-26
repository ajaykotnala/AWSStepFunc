

<meta name='keywords' content='AWS Step Functions'>
<meta name='description' content='aws-lambda-function-error-handling-with-aws-step-functions'>
<meta name='subject' content='aws-lambda-function-error-handling-with-aws-step-functions'>

# AWS-lambda-function-error-handling-with-aws-step-functions
[![Release](https://img.shields.io/badge/release-1.0.2-brightgreen.svg)](#) [![Updated](https://img.shields.io/badge/date-June%2031%2C%202018-orange.svg)](#) [![NuGet Badge](https://buildstats.info/nuget/Amazon.Lambda.Core)](https://www.nuget.org/packages/Amazon.Lambda.Core/) [![.NET](https://img.shields.io/badge/.NET-%3E%3D%204.5.1-ff69b4.svg)](#)


## What Is AWS Step Functions?
AWS Step Functions is a web service that enables you to coordinate the components of distributed applications and microservices using visual workflows. You build applications from individual components that each perform a discrete function, or task, allowing you to scale and change applications quickly. Step Functions provides a reliable way to coordinate components and step through the functions of your application. Step Functions provides a graphical console to visualize the components of your application as a series of steps. It automatically triggers and tracks each step, and retries when there are errors, so your application executes in order and as expected, every time. Step Functions logs the state of each step, so when things do go wrong, you can diagnose and debug problems quickly.


## AWS Step Fuction WorkFlow

<img src="https://github.com/ajaykotnala/AWSStepFunc/blob/master/AWSServerless/img/visual-flow.PNG" />


the project do include customerror class which simply is extension (inherit from Exception class)
```C#
class CustomException: Exception
    {
        public CustomException(string message): base(message)
        {

        }
    }
```


## Executing Stepfunction 

<img src="https://github.com/ajaykotnala/AWSStepFunc/blob/master/AWSServerless/img/all-well.PNG" />


## Executing with custom error  

<img src="https://github.com/ajaykotnala/AWSStepFunc/blob/master/AWSServerless/img/custom-error.PNG" />



## Steps which explains what this project is doing? 

* explain about your serverless.template and exception handling
* explain about how those error can occur
* explain about retry mech
* explain about how logging of each step will be done(TBD)
* explain about if eveything goes fine then what and how it will look


##  Important Links to go through with:

* [Best Practices for Step Functions.](https://docs.aws.amazon.com/step-functions/latest/dg/sfn-best-practices.html?shortFooter=true)
* [Use Timeouts to Avoid Stuck Executions.](https://docs.aws.amazon.com/step-functions/latest/dg/sfn-stuck-execution.html?shortFooter=true)
* [Handle Lambda Service Exceptions.](https://docs.aws.amazon.com/step-functions/latest/dg/sfn-best-practices.html?shortFooter=true)
* [Logging Step Functions using CloudTrail.](https://docs.aws.amazon.com/step-functions/latest/dg/procedure-cloud-trail.html?shortFooter=true)
* [States.](https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-states.html?shortFooter=true)
* [What Is AWS Step Functions?](https://docs.aws.amazon.com/step-functions/latest/dg/welcome.html?shortFooter=true)



# Step Functions Hello World

This starter project consists of:

* serverless.template - An AWS CloudFormation template file for declaring your Serverless functions and other AWS resources
* state-machine.json -The definition of the Step Function state machine.
* StepFunctionTasks.cs - This class contains the Lambda functions that the Step Function state machine will call.
* State.cs - This class represent the state of the step function executions between Lambda function calls.
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS

You may also have a test project depending on the options selected.

The generated project is a simple hello world Step Functions example. It generates 2 Lambda functions that are called as tasks in a state machine. In the state-machine.json file the Step Function state machine is defined that tells the Step Function service in what order to call the Lambda functions. The Step Function execution's state is maintained in the State object which the Lambda functions read from, populate and return. In this example the first Lambda function also returns back a wait time to show how to configure a wait in the state machine.

### Defining a State Machine

The state machine is defined in the state-machine.json file. When the project is deployed the contents of state-machine.json are copied into the serverless.template. The insertion location is controlled by the --template-substitutions parameter. The project template presets the --template-substitutions parameter in aws-lambda-tools-defaults.json. The format of the value for --template-substitutions is <json-path>=<file-name>.

For example this project template sets the value to be:

--template-substitutions $.Resources.StateMachine.Properties.DefinitionString.Fn::Sub=state-machine.json

### Test State Machine

Once the project is deployed you can test it with the Step Functions in the web console https://console.aws.amazon.com/states/home. Select the newly created state machine and then click the "New Execution" button. Enter the initial JSON document for the input to the execution which will be serialized in to the State object. This project will look for a "Name" property to use in its execution. Here is an example input JSON.

{
    "Name" : "MyStepFunctions"
}

## Here are some steps to follow from Visual Studio:

To deploy your Serverless application, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed application open the Stack View window by double-clicking the stack name shown beneath the AWS CloudFormation node in the AWS Explorer tree. The Stack View also displays the root URL to your published application.

## Here are some steps to follow to get started from the command line:

Once you have edited your template and code you can use the following command lines to deploy your application from the command line (these examples assume the project name is *AWSServerless*):

Restore dependencies
```
    cd "AWSServerless"
    dotnet restore
```

Execute unit tests
```
    cd "AWSServerless/test/AWSServerless.Tests"
    dotnet test
```

Deploy application
```
    cd "AWSServerless/src/AWSServerless"
    dotnet lambda deploy-serverless
```




