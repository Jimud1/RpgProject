The idea for my game is to be a story telling rpg that is mainly story driven with points in the 
story where the user can make choices which values will need ot be saved to determine which stories the user will have availiable.

I have decided to use Json as my data source, for easy editing and use
I have created a repository for which the stories to get pulled from.

I have created a Story Service as a main entry point for the repository, so far have only implemented the Get functions, have no need for more yet.

Story is made up of 
Id, 
Name (Breif description of the story),
List of conversations

Conversation contains
Id, 
Text which will be displayed to user,
Conversation options, list of dictonary
list of Story Lead Id's, The storys that lead off from this conversation

Example story model Json, an array of Stories
[
  {
    "story_id": 1,
    "title": "Start",
    "conversations": [
      {
        "conversation_id": 1,
        "conversation_text": "Wake up young man, it's time to leave!",
        "conversation_options": { "What's going on?" : null , "You leave!": null , "Let's go": null } 
      },
      {
        "conversation_id": 2,
        "conversation_text": "There's no time for that, we're going, we're under attack",
        "conversation_options": { "Let's go then": null , "We must do something!": null } 
      },
      {
        "conversation_id": 3,
        "conversation_text": "Go over to the box and get the Armour and sword",
        "conversation_options": { "Ok then" : 2 } ,
        "story_lead_id": [ 2 ]
      }
    ]
  }
]

I will use this same principle going forward for everything within the game  for example, items, monsters, etc
