
 
 import { BrowserRouter as Router, Route, Routes , Link } from 'react-router-dom';
import './App.css'
import Home from './Components/Home';
import Contact from './Components/Conatc';
import UseEffectEx from './Components/UseEffectEx';
import Product from './Components/product';
import EditProduct from './Components/EditProduct';
import NotFound from './Components/NotFound';
function App() {
  return (
        <div>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/c">Contact</Link></li>
          <li><Link to="/h">useEffect ex</Link></li>
          <li><Link to="/p"> Product</Link></li>
        
        </ul>
      </nav>


      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="c" element={<Contact />} />
        <Route path="h" element={<UseEffectEx />} />
        <Route path="p" element={<Product />} />
        <Route path='editcate/:id?' element={<EditProduct/>}/>

        <Route path='*' element={<NotFound/>}/>
      </Routes>
      </div>
     
   
  )
}

export default App
