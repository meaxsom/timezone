# timezone

A command line implementation of [Coding Challenge #85](https://codingchallenges.substack.com/p/coding-challenge-85-time-zone-converter)

Using this as a vehicle to understand the C# language, its ecosystem, and coding guidelines; the .Net framework; VS Code as the IDE for a C# project; and using an AI assistant ([Phind](https://www.phind.com)) - as opposed to Google'ing - to answer questions/find solutions.

## Activity

### Day 1

#### Step 0
Used a premade Dev container for C#/.Net development. Reasonbally easy to set up. Rather than setting up a dev container for each C# project, I'll use a single container and just have different repos for the project.

Spent some time asking Phind about structuring C# projects, the difference/relationship between a "project" and a "solution", what VS code extensions to use/install, how to have VS code create a projects from a template, how to add in unit testing, and how `NuGet` packages are installed/dependencies created.

#### Step 1
Asked Phind about a command line parser for C# and selected [Spectre.Console](https://spectreconsole.net). Had it geterate a sample C# command line applicaiotn using Spectre.Console to take in some arguments as a way to get started. C# looks/feels a lot like Java and Swift based on the sample code. The syntax and structure was similar.

Asked about Classes vs Structs in C# - interesting. Similar in some ways to Swift.

Got down to coding up the command line inputs I wanted to fulfill the first step of the challenge.

Found a downloadable [Timezone table](https://github.com/bproctor/timezones) that I can use for data import. Wrote some structs to handle de-serializing a CSV timezone file into `Zone` objects held in a dictionay by timezone name (I'll get to abbreviations later). Used [CsvHelper](https://joshclose.github.io/CsvHelper/) to make de-serializing CSV easier.

Tried and failed to get the `XUnit` testing framework set up so I could test the structs. Phind was helpful in getting me pointed in the right direction but I'm obviously missing something and put it it on the shelf for the day.

### Day 2

Still on step 1. Since I can't set up tests yet, I opted to use the debugger to see if the code was working properly. That opened up a can of worms understanding `launch.json` and `task.json` files. Phind was very helpful in generating examples that I tweaked. Eventually had a working setup from the "Run/Debug" icon for the project where I can pass in arguments in for debugging - `X Code` is much better at that! 

Still want add testing but I think I can move on. Also probably should add this to GitHub. Asked Phind to generate a typical `.gitignore` file for C# projects. 

#### Step 2

Created a couple more structs to handle keeping track of selected zones and which one is the selected/default zone and loaded up the default and additional timezones from the command line argumnet into the tracking list.

Had to ask Phind about `nullable` type and how to "unwrap" them. Same/similar concept to "optionals" in Swift. For some reason it was more understandable here.

Create an inital sort of the list base on timeazone name

## Notes

I'm noticing that I have 2 `.vscode` directories - one at the top level of my workspace and one w/in the project. I think VS Code is using the one at the top level instead of the one w/in the project. Wonder how I get it to use the one in the project?


## Resources

- [Timezone Abbreviations](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones#Time_zone_abbreviations)
