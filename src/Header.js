// Header.js
import React from 'react';
import { Navbar, Nav, NavDropdown, Form, FormControl, Button } from 'react-bootstrap';
import 'bootstrap-icons/font/bootstrap-icons.css';

const Header = () => {
  return (
    <Navbar bg="light" expand="lg">
      <div className="container-fluid">
        <Navbar.Brand href="#"><i className="bi bi-film"></i> eIngressos</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav className="me-auto my-2 my-lg-0" navbarScroll>
            <Nav.Link href="#"> Filmes</Nav.Link>
            <NavDropdown title={<span><i className="bi bi-gear"></i> Gestão</span>} id="navbarScrollingDropdown">
              <NavDropdown.Item href="/actor">Atores</NavDropdown.Item>
              <NavDropdown.Item href="/movies">Filmes</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="/sessoes">Sessoes</NavDropdown.Item>
              <NavDropdown.Item href="#">Clientes</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Form className="d-flex me-3">
            <FormControl
              type="search"
              placeholder="Search"
              className="me-2"
              aria-label="Search"
            />
            <Button variant="outline-success">Search</Button>
          </Form>
          <Nav className="ml-auto">
            <Nav.Link href="#"><span className="fas fa-user"></span> Sign Up</Nav.Link>
            <Nav.Link href="#"><span className="fas fa-sign-in-alt"></span> Login</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </div>
    </Navbar>
  );
};

export default Header;
