# Avo

Pure .net library :) no dependancy required 

## Getting Started

Just donwload and run it on your machine . 

### Prerequisites

.net 4.5 but you can downgrade it cause most the things are also available in lower version of .net framework

### Examples !!!! note that i did not include all examples but you can easily read though the classes

##### Date

```
 // get date of birth 
    DateTime myDateOfBirth = new DateTime(1994 , 03 , 05);
    int myAge =  myDateOfBirth.CurrrentYearDifference();
    //25
```

DataTable

```
DataTable dtSubject = new DataTable();
            dtSubject.Columns.Add("subjectId");
            dtSubject.Columns.Add("name");
             
            string htmlData = dtSubject.ToHtmlTable(null); 
			
            // Removes duplicates in rows based on column value
            dtSubject.RemoveDuplicateRows("224"); 
```

Excel has brackets as negatives ()
``` 
            string excelNegativeValue = "(200)"; 
            string formated = excelNegativeValue.ToNegativeBracketFormat();
		    	// -200
```
 
 String
 ```
  // shorten string by number of words and character 
            string longString  = "All programmers are happy";

            var result = longString.Excerpt("...", 2, 100);
			//All programmers...

            var result2 = longString.Excerpt("...", 2, 10);
			//All progra 
 ```


## Versioning

1.1

## Authors

* **Billy Watsikenyere** -

See also the list of [contributors](https://github.com/billywatsy/avo/contributors) who participated in this project.

