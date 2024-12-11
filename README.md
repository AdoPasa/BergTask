## Initial App Startup
1) Create an MSSQL database and adjust the connection string.
2) Restore the NuGet packages and build the solution.
3) Set the Web project as the startup project.
4) Apply the migrations from the Infrastructure project.
5) Run the application.

## App Features
### Synonym Page:  
* Users can view synonym details, including word usage, examples, meaning, and phonetics (with audio).

### Add Synonym:
* Use the add "Here" link to add a new synonym (found on index and error pages). 
* When adding a new synonym, both the name and description are required.
* If a similar word exists, you can assign it as a parent, and all related synonyms will automatically be assigned to the newly added word.
* After submitting the form, the system will automatically fetch additional data from an external dictionary (if available - external api integration).
* Once the synonym is added, the user will be redirected to the synonym page, where they can see the full entry, including the fetched additional data.


### Synonym Search (Ajax call):
* In the header of the layout, there is a search bar with autocomplete functionality.
* After entering a search term, the system will return suggestions. After the user selects an existing word, they will be redirected to the synonym page.
