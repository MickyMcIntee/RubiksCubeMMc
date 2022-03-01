# RubiksCubeMMc
# Michael McIntee
# V1.0

The solution should work correctly from a simple pull and then running the solution. You're met with menu options, some of which are implemented fully and some aren't.

1. Rotate Clockwise
2. Rotate Anticlockwise
3. Print Cube
4. Exit

When selection an operation for rotation, the next menu allows you to select the face to rotate. Based on what I've managed to do, only the front and top for clockwise
rotation will work correctly. This is because a mapping exists for each face, highlighting what values of the neighbours are copied to which other face on the rotation.

This isn't the best way to do this and was down to time constraints. Had I had more time, I would look at adding location and neighbour references to 'Squares' where each
square stores a record of all adjacent neighbours. This means that the face can be rotated, and depending on its location, it would write its neighbour value to the value 
of the neighbour that now sits next to it on other faces. This would reduce the amount of code required, and I believe it would reduce the coupling in code units. 

In terms of the menu, this was also very basic just as a means to get it done quickly - in future, with more time, I'd make use of console argument libraries so it could work
as a console application that accepted commands with arguments, rather than menu options.

e.g., instead of 1 to rotate clockwise, then 1 again to select front face, the user could type 'rotate front', or 'antirotate bottom'.

I'd also write the program in a console container with command line interfaces so that they could be mocked to write better unit tests, which as it stands I haven't gotten
round to, but the program itself couldn't be easily mocked and tested. Only the models could. 

I would also look into the app configs a bit more for the strings setup, I've taken strings into the config because they could differ between localities and could be
changed in one place and propogated elsewhere, but the i'd also likely use interpolation, rather than having a string for every possible operation.

Thank you :)

Michael
