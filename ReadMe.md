# Adventure Game

Let's create an adventure game.

- Continue from the base by adding more rooms and dialogues and things to explore throughout the game.
- Go wild and crazy and add items, inventory, or even an enemy to fight before you're able to escape!

## Create a room:

In the RoomData class you can find a method called: `CreateRooms();` where I created the first room (the entrance) and three additional rooms to continue from.

To add more rooms you can place them in the `CreateRooms()` method, under the **entrance** as its used as the first room we start from.

Here´s how to do create one:
- Start by creating the variable: `var room = new Room.RoomBuilder()`
- Then continue chaining the additional information with the dot notation:
  - `.AddRoomId("Entrance")`
  - `.AddDialogue("A Dialogue of some sorts!")`
  - `.AddAdjacentRoom(Directions.Up, "To Room ID")`
- And then finally build the room by calling:
- `.Build();`
- And lastly, add the room to the room dictionary with the ID and the room itself: `rooms.Add(room.RoomId, room);`

Take note that for every chain we only separate it with a (`.`) dot and **only** end with a (`;`) when calling `Build()`.

### Example build of room

```csharp
var room = new Room.RoomBuilder()
    .AddRoomId("Attic") // Add room id
    .AddDialogue("You've stepped up into the attic.\nIt's a chilling environment but there seems to be a lot of items of use.") // Add room dialogue(s)
    .AddDialogue("Your eyes gaze around the room and you take notice of an unusual looking chest.\nShould you open it or stay away?")
    .AddAdjacentRoom(Directions.Down, "UpperHallway")// Add adjacent room(s)
    .AddAdjacentRoom(Directions.Right, "InnerAttic")// Add adjacent room(s)
    .Build();

rooms.Add(room.RoomId, room);
```

---

If you want to create a dialogue that is longer and spans for multiple lines you need to keep them in one `AddDialogue()` and make use of the `\n` to change line so that the text is not too long to read through and we keep the dialogue somewhat "boxed".

## Example of a long split up dialogue

```
You've entered the building and are situated in the grand hall of the mansion:\nA mist creeps along the floor and erie sounds of scraping metal come from beneath your feet, as you\ntry to focus and get an overview of your location in the flickering light of the chandelier.
```

As you can see this is quite the long dialogue, and since every dialogue is treated with a pause ( press any key to continue ), you might want to keep it as one dialogue and make it easier on the eye by splitting the dialogue into sections with `\n`.

---

# TODO

- Add a player class to be able to interact with items and objects
  - Add fields like health, stamina etc
  - Use your imagination
- Add an enemy class of which you might have to fight in certain areas of the house
- Add an inventory for items that might be dropped from enemies or found in the rooms
- Add items to use, a lighter to light a candle? 
- Add more to do in the rooms:
  - Mysteries to solve
  - Items to open up and search through (boxes, chests, an old piano?)
- Add locked doors and matching keys?
- Dark rooms:
  - Without a candle you get one response of what you see
  - And with a candle you get another response