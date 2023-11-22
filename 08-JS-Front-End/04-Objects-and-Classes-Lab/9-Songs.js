function playList(songsArgs) {
  let songs = [];
  const songsCounter = songsArgs[0];
  const type = songsArgs.pop();

  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  for (let song = 1; song <= songsCounter; song++) {
    const [typeList, name, time] = songsArgs[song].split("_");

    songs.push(new Song(typeList, name, time));
  }

  for (const element of songs) {
    if (type === "all") {
      console.log(element.name);
    } else if (element.typeList === type) {
      console.log(element.name);
    }
  }
}

playList([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);

playList([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);

playList([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
