# LeadershipMap
## So what's this?
This project is titled Leadership Map because that's how I used it. Data was collected from student leaders at the Illinois Mathematics and Science Academy on who their friends were, parsed by this program, graphed using Gephi and will eventually be visualized by sigma.js. There will soon be a blog post that will take on most of the roles that a readme normally does but I'll still keep the really nerdy stuff here. 


## Classes

### Academy

It's called the Illinois Mathematics and Science _Academy_, isn't it? This class is where all the information is stored and creats your raw data.

### Leader

Basic informational class that contains data about a leaders organizations, class, name ID and so on.

### Connection
Takes in two leaders as paramter and also accepts ratings.


### SpreadsheetParser
The main class to read a spreadsheet, it has the ability to read a CSV and give easy access to information about the sheet.

#### LeaderParser
Inherited from SpreadsheetParser, this reads a CSV file with the following header row:

`Name,	uniqueID,	class,	hall,	totalPositions,	organization1,	organization2,	organization3,	organization4,	orgnization5` 
and creates one Leader object per row. Pretty simple stuff.

#### ConnectionParser

This Parser is much more complicated. Basically, it creates a reference using the row headers of a sheet formatted like so:

Timestamp | Who are you? | Real Name | uniqueID | Class | RateQuestion1
------------ | ------------- | ------------- | ------------- | ------------- | ------------- 
 |||||leaderName1
IGNORE|IGNORE|IGNORE|IGNORE|IGNORE|leaderID1

Do note that the elements with numbers continue till the end of the survey. Here's how the algorithim works:

1. Start on row _i_
2. Iterate through row _i_ starting with the first rating (under RateQuestion1)
3. Foreach rating, check if there is a connection with those two leaders
  * If not, create one
  * If so, add that rating to the connection
4. i++
5. Repeat till `i<CountRows()`
Finally, it checks with the delegate passed to the parser to verify if that connection is strong enough to deserve an object (and eventually, an edge in the graph). As of this writing, it only gives "perfect" connections (4s on both sides) a connection but this will be altered continously.

### JSONWrapper
Uses Newtonsoft's marvelous Json.NET page to serialize itself as a JSON and return the result. FYI, you'll have to use NuGet package manger to get the package. They describe how to on their [website](http://www.newtonsoft.com/json).
#### LeaderWrapper
Takes a leader object and only includes the necessary fields
#### ConnectionWrapper
Ditto for connections
### GephiExporter
Pass it a list of connections, leaders or (coming soon!) Academy object and a file location and it will create a `nodes.csv` and `edges.csv` file that Gephi will import in. From there, I suggest using their layout tools in preparation for sigma.js

## License & Usage
Licensed under the MIT license.
If you find a problem, create an issue and I'll take a look or (better!) make a pull request with your fix.

Drop me a line if you want any of the other stuff I used in creating this project - like the original google forms or the script I used to make the Google form so I didn't create a 72 line form by hand.

Cheers!
