function songsList(info){
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }

        play(){
            console.log(`${this.name}`);
        }
    }

    let songs = [];

    let songsNumber = info[0];
    let typeList = info[info.length-1];

    for (let i = 1; i < info.length-1; i++) {
        let tokens = info[i].split('_');

        let type = tokens[0]
        let name = tokens[1];
        let time = tokens[2];
        
        songs.push(new Song(type, name, time))
    }

    if (typeList === 'all') {
        for (const song of songs) {
            song.play();
        }
    } else {
        for (const song of songs) {
            if (song.typeList === typeList) {
                song.play();
            }
        }
    }
}


songsList(
    [3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
);