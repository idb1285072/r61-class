
 
 import { BrowserRouter as Router, Route, Routes , Link } from 'react-router-dom';
import './App.css'
import Home from './Components/Home';
import Contact from './Components/Conatc';

function App() {
 
  

  return (
        <div>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/c">Contact</Link></li>
        </ul>
      </nav>


      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="c" element={<Contact />} />
      </Routes>
      </div>
     
   
  )
}

export default App
