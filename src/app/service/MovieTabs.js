import React, { useState, useEffect } from 'react';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { fetchMovies, fetchMovieDetails, createMovie, updateMovie, deleteMovie } from './api';

const MovieTabs = () => {
  const [movies, setMovies] = useState([]);
  const [selectedMovieId, setSelectedMovieId] = useState(null);
  const [movie, setMovie] = useState({
    id: 0,
    title: '',
    description: '',
    image: '',
    duration: '',
    ageRating: '',
    producer: '',
    category: '',
    priceAux: '',
    price: '',
    actors: [],
    sessions: []
  });
  const [isEditing, setIsEditing] = useState(false);
  const [tabIndex, setTabIndex] = useState(0);

  useEffect(() => {
    const getMovies = async () => {
      try {
        const data = await fetchMovies();
        console.log('Movies in useEffect:', data);
        setMovies(data);
      } catch (error) {
        console.error('Error fetching movies:', error);
      }
    };
    getMovies();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setMovie({ ...movie, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (movie.id === 0) {
        await createMovie(movie);
        alert('Movie created successfully!');
      } else {
        await updateMovie(movie.id, movie);
        alert('Movie updated successfully!');
      }
      setMovie({
        id: 0,
        title: '',
        description: '',
        image: '',
        duration: '',
        ageRating: '',
        producer: '',
        category: '',
        priceAux: '',
        price: '',
        actors: [],
        sessions: []
      });
      setSelectedMovieId(null);
      setIsEditing(false);
      setTabIndex(0); // Voltar para a lista de filmes após salvar
      const data = await fetchMovies();
      console.log('Movies after submit:', data);
      setMovies(data);
    } catch (error) {
      console.error('Error submitting form:', error);
      alert(`Error: ${error.message}`);
    }
  };

  const handleDetailsClick = async (id) => {
    try {
      setSelectedMovieId(id);
      setIsEditing(false);
      setTabIndex(2); // Ir para a aba de detalhes
      const data = await fetchMovieDetails(id);
      console.log('Movie details on details click:', data);
      setMovie(data);
    } catch (error) {
      console.error('Error fetching movie details:', error);
    }
  };

  const handleEditClick = async (id) => {
    try {
      setSelectedMovieId(id);
      setIsEditing(true);
      setTabIndex(2); // Ir para a aba de edição
      const data = await fetchMovieDetails(id);
      console.log('Movie details on edit click:', data);
      setMovie(data);
    } catch (error) {
      console.error('Error fetching movie details:', error);
    }
  };

  const handleDeleteClick = async (id) => {
    if (window.confirm('Are you sure you want to delete this movie?')) {
      try {
        await deleteMovie(id);
        const data = await fetchMovies();
        console.log('Movies after delete:', data);
        setMovies(data);
      } catch (error) {
        console.error('Error deleting movie:', error);
      }
    }
  };

  const handleCancelClick = (e) => {
    e.preventDefault();
    setSelectedMovieId(null);
    setIsEditing(false);
    setTabIndex(0); // Voltar para a lista de filmes
    setMovie({
      id: 0,
      title: '',
      description: '',
      image: '',
      duration: '',
      ageRating: '',
      producer: '',
      category: '',
      priceAux: '',
      price: '',
      actors: [],
      sessions: []
    });
  };

  return (
    <div className="container mt-4">
      <Tabs selectedIndex={tabIndex} onSelect={index => setTabIndex(index)}>
        <TabList>
          <Tab>List</Tab>
          <Tab>Create</Tab>
          <Tab disabled={!selectedMovieId}>Details/Edit</Tab>
        </TabList>

        <TabPanel>
          <h2>Movies List</h2>
          {movies.length === 0 ? (
            <p>No movies available.</p>
          ) : (
            <table className="table table-striped">
              <thead>
                <tr>
                  <th>Poster</th>
                  <th>Title</th>
                  <th>Description</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                {movies.map((movie) => (
                  <tr key={movie.id}>
                    <td>
                      <img src={movie.image} alt={movie.title} style={{ maxWidth: '100px' }} />
                    </td>
                    <td>{movie.title}</td>
                    <td>{movie.description}</td>
                    <td>
                      <button className="btn btn-info me-2" onClick={() => handleDetailsClick(movie.id)}>Details</button>
                      <button className="btn btn-warning me-2" onClick={() => handleEditClick(movie.id)}>Edit</button>
                      <button className="btn btn-danger" onClick={() => handleDeleteClick(movie.id)}>Delete</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </TabPanel>
        <TabPanel>
          <h2>Create Movie</h2>
          <form onSubmit={handleSubmit} className="d-flex flex-column align-items-center">
            <div className="mb-3 col-6">
              <label className="form-label">Title</label>
              <input type="text" className="form-control" name="title" value={movie.title} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Description</label>
              <input type="text" className="form-control" name="description" value={movie.description} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Poster URL</label>
              <input type="text" className="form-control" name="image" value={movie.image} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Duration (Minutes)</label>
              <input type="text" className="form-control" name="duration" value={movie.duration} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Age Rating</label>
              <input type="text" className="form-control" name="ageRating" value={movie.ageRating} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Producer</label>
              <input type="text" className="form-control" name="producer" value={movie.producer} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Category</label>
              <input type="text" className="form-control" name="category" value={movie.category} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Price</label>
              <input type="text" className="form-control" name="priceAux" value={movie.priceAux} onChange={handleInputChange} />
            </div>
            <div className="d-flex justify-content-between col-6">
              <button type="submit" className="btn btn-primary me-2">Create</button>
              <button className="btn btn-secondary" onClick={handleCancelClick}>Cancel</button>
            </div>
          </form>
        </TabPanel>
        <TabPanel>
          <h2>{isEditing ? 'Edit Movie' : 'Movie Details'}</h2>
          {selectedMovieId ? (
            <form onSubmit={handleSubmit} className="d-flex flex-column align-items-center">
              <div className="mb-3 col-6">
                <label className="form-label">Title</label>
                <input type="text" className="form-control" name="title" value={movie.title} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Description</label>
                <input type="text" className="form-control" name="description" value={movie.description} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Poster URL</label>
                <input type="text" className="form-control" name="image" value={movie.image} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Duration (Minutes)</label>
                <input type="text" className="form-control" name="duration" value={movie.duration} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Age Rating</label>
                <input type="text" className="form-control" name="ageRating" value={movie.ageRating} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Producer</label>
                <input type="text" className="form-control" name="producer" value={movie.producer} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Category</label>
                <input type="text" className="form-control" name="category" value={movie.category} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Price</label>
                <input type="text" className="form-control" name="priceAux" value={movie.priceAux} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              {isEditing ? (
                <div className="d-flex justify-content-between col-6">
                  <button type="submit" className="btn btn-primary me-2">Save Changes</button>
                  <button className="btn btn-secondary" onClick={handleCancelClick}>Cancel</button>
                </div>
              ) : (
                <div className="d-flex justify-content-between col-6">
                  <button className="btn btn-primary me-2" onClick={() => setIsEditing(true)}>Edit</button>
                  <button className="btn btn-secondary" onClick={handleCancelClick}>Close</button>
                </div>
              )}
            </form>
          ) : (
            <p>Please select a movie to view details.</p>
          )}
        </TabPanel>
      </Tabs>
    </div>
  );
};

export default MovieTabs;
