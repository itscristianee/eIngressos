const API_BASE_URL_Actor = 'http://localhost:5009/api/ActorsApi';

export const fetchActors = async () => {
  const requestOptions = {
    method: 'GET',
    redirect: 'follow',
  };

  try {
    const response = await fetch(API_BASE_URL_Actor, requestOptions);
    console.log('Fetch response:', response);
    if (!response.ok) {
      const errorBody = await response.text();
      console.error('Fetch actors failed:', response.status, errorBody);
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    console.log('fetchActors response:', data);
    return data;
  } catch (error) {
    console.error('Fetch actors failed:', error);
    throw error;
  }
};

export const fetchActorDetails = async (id) => {
  const requestOptions = {
    method: 'GET',
    redirect: 'follow',
  };

  try {
    const response = await fetch(`${API_BASE_URL_Actor}/${id}`, requestOptions);
    console.log('Fetch response:', response);
    if (!response.ok) {
      const errorBody = await response.text();
      console.error('Fetch actor details failed:', response.status, errorBody);
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    console.log('fetchActorDetails response:', data);
    return data;
  } catch (error) {
    console.error('Fetch actor details failed:', error);
    throw error;
  }
};

export const createActor = async (actor) => {
  const myHeaders = new Headers();
  myHeaders.append('Content-Type', 'application/json');

  const requestOptions = {
    method: 'POST',
    headers: myHeaders,
    body: JSON.stringify(actor),
    redirect: 'follow',
  };

  try {
    const response = await fetch(API_BASE_URL_Actor, requestOptions);
    console.log('Fetch response:', response);
    if (!response.ok) {
      const errorBody = await response.text();
      console.error('Create actor failed:', response.status, errorBody);
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    console.log('createActor response:', data);
    return data;
  } catch (error) {
    console.error('Create actor failed:', error);
    throw error;
  }
};

export const updateActor = async (id, actor) => {
  const myHeaders = new Headers();
  myHeaders.append('Content-Type', 'application/json');

  const requestOptions = {
    method: 'PUT',
    headers: myHeaders,
    body: JSON.stringify(actor),
    redirect: 'follow',
  };

  try {
    const response = await fetch(`${API_BASE_URL_Actor}/${id}`, requestOptions);
    console.log('Fetch response:', response);
    if (!response.ok) {
      const errorBody = await response.text();
      console.error('Update actor failed:', response.status, errorBody);
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    console.log('updateActor response:', data);
    return data;
  } catch (error) {
    console.error('Update actor failed:', error);
    throw error;
  }
};

export const deleteActor = async (id) => {
  const requestOptions = {
    method: 'DELETE',
    redirect: 'follow',
  };

  try {
    const response = await fetch(`${API_BASE_URL_Actor}/${id}`, requestOptions);
    console.log('Fetch response:', response);
    if (!response.ok) {
      const errorBody = await response.text();
      console.error('Delete actor failed:', response.status, errorBody);
      throw new Error('Network response was not ok');
    }
    console.log('deleteActor response:', response);
    return response;
  } catch (error) {
    console.error('Delete actor failed:', error);
    throw error;
  }
};


//movies

const API_BASE_URL_MOVIE = 'http://localhost:5009/api/MoviesApi';

export const fetchMovies = async () => {
  const requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  try {
    const response = await fetch(API_BASE_URL_MOVIE, requestOptions);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.json(); // Assuming the response is JSON, change if needed
    console.log(result);
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
};

export const createMovie = async (movie) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const raw = JSON.stringify(movie);

  const requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: raw,
    redirect: "follow"
  };

  try {
    const response = await fetch(API_BASE_URL_MOVIE, requestOptions);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.text();
    console.log(result);
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
};

export const updateMovie = async (movieId, movie) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const raw = JSON.stringify(movie);

  const requestOptions = {
    method: "PUT",
    headers: myHeaders,
    body: raw,
    redirect: "follow"
  };

  try {
    const response = await fetch(`${API_BASE_URL_MOVIE}/${movieId}`, requestOptions);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.text();
    console.log(result);
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
};

export const deleteMovie = async (movieId) => {
  const requestOptions = {
    method: "DELETE",
    redirect: "follow"
  };

  try {
    const response = await fetch(`${API_BASE_URL_MOVIE}/${movieId}`, requestOptions);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.text();
    console.log(result);
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
};

export const fetchMovieDetails = async (movieId) => {
  const requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  try {
    const response = await fetch(`${API_BASE_URL_MOVIE}/${movieId}`, requestOptions);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const result = await response.json(); // Assuming the response is JSON, change if needed
    console.log(result);
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
};


//Sessions


export const fetchSessions = async () => {
  const requestOptions = {
    method: "GET",
    redirect: "follow"
  };

  try {
    const response = await fetch("http://localhost:5009/api/SessionsApi", requestOptions);
    if (!response.ok) {
      throw new Error('Network response was not ok ' + response.statusText);
    }
    const result = await response.json();
    return result;
  } catch (error) {
    console.error('There has been a problem with your fetch operation:', error);
  }
};

export const createSession = async (sessionData) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: JSON.stringify(sessionData),
    redirect: "follow"
  };

  try {
    const response = await fetch("http://localhost:5009/api/SessionsApi", requestOptions);
    if (!response.ok) {
      throw new Error('Network response was not ok ' + response.statusText);
    }
    const result = await response.json();
    return result;
  } catch (error) {
    console.error('There has been a problem with your fetch operation:', error);
  }
};

export const deleteSession = async (sessionId) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const requestOptions = {
    method: "DELETE",
    headers: myHeaders,
    redirect: "follow"
  };

  try {
    const response = await fetch(`http://localhost:5009/api/SessionsApi/${sessionId}`, requestOptions);
    if (!response.ok) {
      throw new Error('Network response was not ok ' + response.statusText);
    }
    const result = await response.text();
    return result;
  } catch (error) {
    console.error('There has been a problem with your fetch operation:', error);
  }
};

export const updateSession = async (sessionId, sessionData) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const requestOptions = {
    method: "PUT",
    headers: myHeaders,
    body: JSON.stringify(sessionData),
    redirect: "follow"
  };

  try {
    const response = await fetch(`http://localhost:5009/api/SessionsApi/${sessionId}`, requestOptions);
    if (!response.ok) {
      throw new Error('Network response was not ok ' + response.statusText);
    }
    const result = await response.json();
    return result;
  } catch (error) {
    console.error('There has been a problem with your fetch operation:', error);
  }
};

export const patchSession = async (sessionId, sessionData) => {
  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  const requestOptions = {
    method: "PATCH",
    headers: myHeaders,
    body: JSON.stringify(sessionData),
    redirect: "follow"
  };

  try {
    const response = await fetch(`http://localhost:5009/api/SessionsApi/${sessionId}`, requestOptions);
    if (!response.ok) {
      throw new Error('Network response was not ok ' + response.statusText);
    }
    const result = await response.json();
    return result;
  } catch (error) {
    console.error('There has been a problem with your fetch operation:', error);
  }
};
