import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import HomeComponent from './components/HomeComponent';
import LoginComponent from './components/LoginComponent';

function App() {
  return (
    <div>
    <BrowserRouter>
      <Routes>
        <Route path="/home" element={<HomeComponent />} />
        <Route path="/login" element={<LoginComponent />} />
        <Route path="/" element={<LoginComponent />} />
      </Routes>
    <div className="App">
      
    </div>
    </BrowserRouter>
    </div>
  );
}

export default App;
