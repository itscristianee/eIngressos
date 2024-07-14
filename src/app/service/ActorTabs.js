import React, { useState, useEffect } from 'react';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { fetchActors, fetchActorDetails, createActor, updateActor, deleteActor } from './api';

const ActorTabs = () => {
  const [actors, setActors] = useState([]);
  const [selectedActorId, setSelectedActorId] = useState(null);
  const [actor, setActor] = useState({
    id: 0,
    name: '',
    bio: '',
    photo: '',
    actedIns: null  // Ajustando para o campo correto
  });
  const [isEditing, setIsEditing] = useState(false);
  const [tabIndex, setTabIndex] = useState(0);

  useEffect(() => {
    const getActors = async () => {
      try {
        const data = await fetchActors();
        console.log('Actors in useEffect:', data);
        setActors(data);
      } catch (error) {
        console.error('Error fetching actors:', error);
      }
    };
    getActors();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setActor({ ...actor, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (actor.id === 0) {
        await createActor(actor);
        alert('Actor created successfully!');
      } else {
        await updateActor(actor.id, actor);
        alert('Actor updated successfully!');
      }
      setActor({
        id: 0,
        name: '',
        bio: '',
        photo: '',
        actedIns: null  // Ajustando para o campo correto
      });
      setSelectedActorId(null);
      setIsEditing(false);
      setTabIndex(0); // Voltar para a lista de atores após salvar
      const data = await fetchActors();
      console.log('Actors after submit:', data);
      setActors(data);
    } catch (error) {
      console.error('Error submitting form:', error);
      alert(`Error: ${error.message}`);
    }
  };

  const handleDetailsClick = async (id) => {
    try {
      setSelectedActorId(id);
      setIsEditing(false);
      setTabIndex(2); // Ir para a aba de detalhes
      const data = await fetchActorDetails(id);
      console.log('Actor details on details click:', data);
      setActor(data);
    } catch (error) {
      console.error('Error fetching actor details:', error);
    }
  };

  const handleEditClick = async (id) => {
    try {
      setSelectedActorId(id);
      setIsEditing(true);
      setTabIndex(2); // Ir para a aba de edição
      const data = await fetchActorDetails(id);
      console.log('Actor details on edit click:', data);
      setActor(data);
    } catch (error) {
      console.error('Error fetching actor details:', error);
    }
  };

  const handleDeleteClick = async (id) => {
    if (window.confirm('Are you sure you want to delete this actor?')) {
      try {
        await deleteActor(id);
        const data = await fetchActors();
        console.log('Actors after delete:', data);
        setActors(data);
      } catch (error) {
        console.error('Error deleting actor:', error);
      }
    }
  };

  const handleCancelClick = (e) => {
    e.preventDefault();
    setSelectedActorId(null);
    setIsEditing(false);
    setTabIndex(0); // Voltar para a lista de atores
    setActor({
      id: 0,
      name: '',
      bio: '',
      photo: '',
      actedIns: null  // Ajustando para o campo correto
    });
  };

  return (
    <div className="container mt-4">
      <Tabs selectedIndex={tabIndex} onSelect={index => setTabIndex(index)}>
        <TabList>
          <Tab>List</Tab>
          <Tab>Create</Tab>
          <Tab disabled={!selectedActorId}>Details/Edit</Tab>
        </TabList>

        <TabPanel>
          <h2>Actors List</h2>
          {actors.length === 0 ? (
            <p>No actors available.</p>
          ) : (
            <table className="table table-striped">
              <thead>
                <tr>
                  <th>Photo</th>
                  <th>Name</th>
                  <th>Bio</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                {actors.map((actor) => (
                  <tr key={actor.id}>
                    <td>
                      <img src={actor.photo} alt={actor.name} style={{ maxWidth: '100px' }} />
                    </td>
                    <td>{actor.name}</td>
                    <td>{actor.bio}</td>
                    <td>
                      <button className="btn btn-info me-2" onClick={() => handleDetailsClick(actor.id)}>Details</button>
                      <button className="btn btn-warning me-2" onClick={() => handleEditClick(actor.id)}>Edit</button>
                      <button className="btn btn-danger" onClick={() => handleDeleteClick(actor.id)}>Delete</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </TabPanel>
        <TabPanel>
          <h2>Create Actor</h2>
          <form onSubmit={handleSubmit} className="d-flex flex-column align-items-center">
            <div className="mb-3 col-6">
              <label className="form-label">Name</label>
              <input type="text" className="form-control" name="name" value={actor.name} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Bio</label>
              <input type="text" className="form-control" name="bio" value={actor.bio} onChange={handleInputChange} />
            </div>
            <div className="mb-3 col-6">
              <label className="form-label">Profile Picture URL</label>
              <input type="text" className="form-control" name="photo" value={actor.photo} onChange={handleInputChange} />
            </div>
            <div className="d-flex justify-content-between col-6">
              <button type="submit" className="btn btn-primary me-2">Create</button>
              <button className="btn btn-secondary" onClick={handleCancelClick}>Cancel</button>
            </div>
          </form>
        </TabPanel>
        <TabPanel>
          <h2>{isEditing ? 'Edit Actor' : 'Actor Details'}</h2>
          {selectedActorId ? (
            <form onSubmit={handleSubmit} className="d-flex flex-column align-items-center">
              <div className="mb-3 col-6">
                <label className="form-label">Name</label>
                <input type="text" className="form-control" name="name" value={actor.name} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Bio</label>
                <input type="text" className="form-control" name="bio" value={actor.bio} onChange={handleInputChange} disabled={!isEditing} />
              </div>
              <div className="mb-3 col-6">
                <label className="form-label">Profile Picture URL</label>
                <input type="text" className="form-control" name="photo" value={actor.photo} onChange={handleInputChange} disabled={!isEditing} />
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
            <p>Please select an actor to view details.</p>
          )}
        </TabPanel>
      </Tabs>
    </div>
  );
};

export default ActorTabs;
