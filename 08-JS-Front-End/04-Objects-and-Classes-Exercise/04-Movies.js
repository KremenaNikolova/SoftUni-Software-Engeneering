function moviesInformation(inputArray) {
  const movies = {};

  for (const movieInfo of inputArray) {
    if (movieInfo.includes("addMovie")) {
      const movieName = movieInfo.split("addMovie ")[1];
      movies[movieName] = {};
      movies[movieName].name = movieName;
    } else if (movieInfo.includes("directedBy")) {
      const tokens = movieInfo.split("directedBy ");
      const movieName = tokens[0].trim();
      const director = tokens[1].trim();

      if (movieName in movies) {
        movies[movieName].director = director;
      }
    } else if (movieInfo.includes("onDate")) {
      const tokens = movieInfo.split("onDate ");
      const movieName = tokens[0].trim();
      const date = tokens[1].trim();

      if (movieName in movies) {
        movies[movieName].date = date;
      }
    }
  }

  for (const movie in movies) {
    if (
      "name" in movies[movie] &&
      "director" in movies[movie] &&
      "date" in movies[movie]
    ) {
      console.log(JSON.stringify(movies[movie]));
    }
  }
}

moviesInformation([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);

moviesInformation([
  "addMovie The Avengers",
  "addMovie Superman",
  "The Avengers directedBy Anthony Russo",
  "The Avengers onDate 30.07.2010",
  "Captain America onDate 30.07.2010",
  "Captain America directedBy Joe Russo",
]);
