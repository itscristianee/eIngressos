// FrontOfficeRoutes.js
import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Actor from './app/components/Actors'; // Corrected import path and component name
import Movies from './app/components/Movies'; // Corrected import path and component name
import Sessions from './app/components/Sessions'; // Corrected import path and component name

function FrontOfficeRoutes() { // Changed function name to be more descriptive
  return (
    <Routes>
      <Route path="/actor" element={<Actor />} />
      <Route path="/movies" element={<Movies />} />
      <Route path="/sessions" element={<Sessions />} />
    </Routes>
  );
}

export default FrontOfficeRoutes;
