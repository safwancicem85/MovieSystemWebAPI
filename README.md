# MovieSystemWebAPI

You can freely get this project.

After you pull the projecct don't forget to change connectionstring under appsettings.json

This project is for testing CRUD operations of web API.
The data will be simple movie data.
Another tables like Actor, MovieActor, Playlist etc will be added.

List of endpoints

get api/Movie
 will list all movies on db

post api/Movie
   Used to add new movie into db
   Movie object must be included in body

get api/Movie/{id}
  Used to get movie by provided id

put api/Movie/{id}
  Used to update movie by Id,
  Movie object will be included in body as JSON

delete api/Movie/{id}
  Used to delete movie
  Soft delete is applied here which means by updating IsDeleted to true

Error handling is implemented globally under 'Extensions' directory.
So, by implementing this section, we won't need to put 'try catch' for every tasks.
