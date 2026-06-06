import React,{useState,useEffect} from 'react'
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';

function EditProduct() {
  const{id}=useParams();
  let navigate=useNavigate()
  const [data, setData] = useState({
    productCategoryID:0,
    name:""
  });
     const [loading, setLoading] = useState(true);
     const [error, setError] = useState(null);
     useEffect(() => {
       // Make GET request to fetch data
       //  .get("https://jsonplaceholder.typicode.com/posts")
       if(id>0)
       {
       axios
           .get("https://localhost:7115/ProductCategories/"+id)
           .then((response) => {
             console.log(response)
               setData(response.data);
               console.log(data)
               setLoading(false);
           })
           .catch((err) => {
               setError(err.message);
               setLoading(false);
               console.log(error)
           });
 
                    }

             setLoading(false);
                              //delete
            //deletedata()
   }, []);
  function submit(){
    if(id>0)
    {
      axios
      .put("https://localhost:7115/ProductCategories/"+id,data)
      .then((response) => {
        console.log(response)
        //navigate(-1);
          navigate('/p')
  
      })
      .catch((err) => {
          setError(err.message);
          setLoading(false);
          console.log(error)
      });
    }
    else
    {
      axios
      .post("https://localhost:7115/ProductCategories/",data)
      .then((response) => {
        console.log(response)
       // navigate(-1);
         navigate('/p')
  
      })
      .catch((err) => {
          setError(err.message);
          setLoading(false);
          console.log(error)
      });
    }
  

  }

   if (loading) return <div>Loading...</div>;
   if (error) return <div>Error: {error}</div>;
  return (
    <div>
      <h2>Edit Product Category</h2>
      <form onSubmit={submit} >
  <div className="form-group">
    <label htmlFor="exampleInputEmail1">Name</label>
    <input type="text" className="form-control" id="exampleInputEmail1"  onChange={e=>setData({...data,name:e.target.value})}
    aria-describedby="emailHelp" placeholder="Enter Name" value={data.name}/>
    <input type="hidden" className="form-control" id="exampleInputPassword1" 
     onChange={e=>setData({...data,productCategoryID:e.target.value})}
    placeholder="id" value={data.productCategoryID} />
  </div>
  
   
  <button type="submit" className="btn btn-primary">Submit</button>
</form>
    </div>
  )
}

export default EditProduct
