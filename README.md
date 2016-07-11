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
and creates one Leader object per row. 
