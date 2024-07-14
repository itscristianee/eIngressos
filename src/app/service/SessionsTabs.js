import React, { useState, useEffect } from 'react';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { fetchSessions, createSession, updateSession, deleteSession } from './api';

const SessionsTabs = () => {
  const [sessions, setSessions] = useState([]);
  const [session, setSession] = useState({
    id: 0,
    theaterId: '',
    movieId: '',
    sessionDateTime: '',
    tickets: []
  });
  const [isEditing, setIsEditing] = useState(false);
  const [tabIndex, setTabIndex] = useState(0);

  useEffect(() => {
    const getSessions = async () => {
      try {
        const data = await fetchSessions();
        console.log('Sessions in useEffect:', data);
        setSessions(data);
      } catch (error) {
        console.error('Error fetching sessions:', error);
      }
    };
    getSessions();
  }, []);

  const handleSessionInputChange = (e) => {
    const { name, value } = e.target;
    setSession({ ...session, [name]: value });
  };

  const handleSessionSubmit = async (e) => {
    e.preventDefault();
    try {
      if (session.id === 0) {
        await createSession(session);
        alert('Session created successfully!');
      } else {
        await updateSession(session.id, session);
        alert('Session updated successfully!');
      }
      setSession({
        id: 0,
        theaterId: '',
        movieId: '',
        sessionDateTime: '',
        tickets: []
      });
      setTabIndex(0); // Voltar para a lista de sessões após salvar
      const data = await fetchSessions();
      console.log('Sessions after submit:', data);
      setSessions(data);
    } catch (error) {
      console.error('Error submitting session form:', error);
      alert(`Error: ${error.message}`);
    }
  };

  const handleEditClick = async (id) => {
    try {
      setIsEditing(true);
      setTabIndex(2); // Ir para a aba de edição
      const sessionToEdit = sessions.find(sess => sess.id === id);
      setSession(sessionToEdit);
    } catch (error) {
      console.error('Error fetching session details:', error);
    }
  };

  const handleDeleteClick = async (id) => {
    if (window.confirm('Are you sure you want to delete this session?')) {
      try {
        await deleteSession(id);
        const data = await fetchSessions();
        console.log('Sessions after delete:', data);
        setSessions(data);
      } catch (error) {
        console.error('Error deleting session:', error);
      }
    }
  };

  const handleCancelClick = (e) => {
    e.preventDefault();
    setIsEditing(false);
    setTabIndex(0); // Voltar para a lista de sessões
    setSession({
      id: 0,
      theaterId: '',
      movieId: '',
      sessionDateTime: '',
      tickets: []
    });
  };

  return (
    <div className="container mt-4">
      <Tabs selectedIndex={tabIndex} onSelect={index => setTabIndex(index)}>
        <TabList>
          <Tab>List</Tab>
          <Tab>Create</Tab>
          <Tab disabled={!isEditing}>Edit</Tab>
        </TabList>

        <TabPanel>
          <h2>Sessions List</h2>
          {sessions.length === 0 ? (
            <p>No sessions available.</p>
          ) : (
            <table className="table table-striped">
              <thead>
                <tr>
                  <th>Theater ID</th>
                  <th>Movie ID</th>
                  <th>Session DateTime</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                {sessions.map((session) => (
                  <tr key={session.id}>
                    <td>{session.theaterId}</td>
                    <td>{session.movieId}</td>
                    <td>{new Date(session.sessionDateTime).toLocaleString()}</td>
                    <td>
                      <button className="btn btn-warning me-2" onClick={() => handleEditClick(session.id)}>Edit</button>
                      <button className="btn btn-danger" onClick={() => handleDeleteClick(session.id)}>Delete</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </TabPanel>
        <TabPanel>
          <h2>Create Session</h2>
          <form onSubmit={handleSessionSubmit} className="d-flex flex-column align-items-center">
            <div className="mb-3 col-6">
              <label className="form-label">Theater ID</label>
              <input type="text" className="form-control" name="theaterId" value={session.theaterId} onChange={handleSessionInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Movie ID</label>
              <input type="text" className="form-control" name="movieId" value={session.movieId} onChange={handleSessionInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Session DateTime</label>
              <input type="datetime-local" className="form-control" name="sessionDateTime" value={session.sessionDateTime} onChange={handleSessionInputChange} />
            </div>
            <div className="d-flex justify-content-between col-6">
              <button type="submit" className="btn btn-primary me-2">Create Session</button>
              <button className="btn btn-secondary" onClick={handleCancelClick}>Cancel</button>
            </div>
          </form>
        </TabPanel>
        <TabPanel>
          <h2>Edit Session</h2>
          <form onSubmit={handleSessionSubmit} className="d-flex flex-column align-items-center">
            <div className="mb-3 col-6">
              <label className="form-label">Theater ID</label>
              <input type="text" className="form-control" name="theaterId" value={session.theaterId} onChange={handleSessionInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Movie ID</label>
              <input type="text" className="form-control" name="movieId" value={session.movieId} onChange={handleSessionInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Session DateTime</label>
              <input type="datetime-local" className="form-control" name="sessionDateTime" value={session.sessionDateTime} onChange={handleSessionInputChange} />
            </div>
            <div className="d-flex justify-content-between col-6">
              <button type="submit" className="btn btn-primary me-2">Save Changes</button>
              <button className="btn btn-secondary" onClick={handleCancelClick}>Cancel</button>
            </div>
          </form>
        </TabPanel>
      </Tabs>
    </div>
  );
};

export default SessionsTabs;
