function moviesList(inputArr) {

    let movies = [];

    for (let index = 0; index < inputArr.length; index++) {
        let movieName = "";
        let movieDate = "";
        let movieDirector = "";

        let movie = {};

        if (inputArr[index].includes("addMovie")) {
            movieName = inputArr[index].split("addMovie ").join("");
            movie.name = movieName;
            movies.push(movie);
        }

        if (inputArr[index].includes("directedBy")) {
            let movieTokens = inputArr[index].split(" directedBy ");
            movieName = movieTokens[0];
            movieDirector = movieTokens[1];

            movies.forEach(movie => {
                if (movie.name === movieName) {
                    movie.director = movieDirector;
                }
            });
        }

        if (inputArr[index].includes("onDate")) {
            let movieTokens = inputArr[index].split(" onDate ");
            movieName = movieTokens[0];
            movieDate = movieTokens[1];

            movies.forEach(movie => {
                if (movie.name === movieName) {
                    movie.date = movieDate;
                }
            });
        }
    }

    for (let index = 0; index < movies.length; index++) {

        if (movies[index].hasOwnProperty("date") && movies[index].hasOwnProperty("director")) {
            console.log(JSON.stringify(movies[index]));
        }
    }

}

moviesList([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]

);