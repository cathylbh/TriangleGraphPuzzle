# TriangleGraphPuzzle
Find the triangle by coordinates
The real logic for this application is in the TriangleLib project.  I choose to put it in a library so that it could be used by more than one interface.  For demo purpose I have simple used a console application, but it could be accessed from a web application as well.  The original problem described a grid that has 12 columns and 6 alpha labeled rows.  It also has column and row widths of 10px.  I don’t like to hard code values like this, so I created a library that uses these values as defaults, but you can specify other values for each of these.  I have a recursive function that will figure out the correct alpha label for the rows if it goes beyond the 26 alphabet characters.  I used the Excel format that goes from Z to AA then AB and so on.
The Console application uses the default values for the grid.  I have added a unit test that will use a large number of rows and verify that the last triangle label returned is correct.
Enjoy!
