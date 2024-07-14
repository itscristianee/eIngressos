// App.js
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import Header from './Header'; // Ensure Header component is in the correct path
import Footer from './Footer'; // Ensure Footer component is in the correct path
import FrontOfficeRoutes from './FrontOfficeRoutes'; // Import the routes component

function App() {
  return (
    <div className="d-flex flex-column min-vh-100">
      <BrowserRouter>
      <Header />
        <FrontOfficeRoutes /> {/* Include your routes here */}
        <Footer />
      </BrowserRouter>
    </div>
  );
}

export default App;
