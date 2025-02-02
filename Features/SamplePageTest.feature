Feature: Sample Page Test

Scenario: Save Sample Page Test Details
Given the user navigates to the sample page test page
When the user selects the profile image
And the user enters the name
And the user presses the TAB key on name field
And the user enters the email
And the user enters the website
And the user selects the experience
And the user selects the expertise
And the user selects the education
And the user enters the comment
And the user clicks on the submit button
Then the sample page test details should be saved

Scenario: Drag drop images
Given the user navigates to the drag drop page
When the user drags and drops all the images to the trash
Then the user should see all the images in the trash
When the user recycles all the images from the trash
Then the user should see all the images back in the drag area

Scenario: Dropdown menu
Given the user navigates to the dropwdown page
When the user select "India" from country dropdown
Then the user should see the "India" selected in country dropdown