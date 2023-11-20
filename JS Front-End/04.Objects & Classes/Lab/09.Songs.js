function songsList(inputArr) {
    let numberOfSongs = inputArr.shift();
    let requiredTypeList = inputArr.pop();

    class Song {

        constructor(songType, songName, songLength) {
            this.songType = songType;
            this.songName = songName;
            this.songLength - songLength;
        }

    }


    for (let index = 0; index < numberOfSongs; index++) {

        let songInfo = inputArr[index].split("_");

        let songType = songInfo[0];
        let songName = songInfo[1];
        let songLength = songInfo[2];

        let song = new Song(songType, songName, songLength);

        if (song.songType === requiredTypeList) {
            console.log(song.songName)
        } else if (requiredTypeList === "all") {
            console.log(song.songName)
        }

    }

}

songsList([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    
    );