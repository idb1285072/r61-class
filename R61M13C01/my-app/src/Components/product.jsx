import React,{useState,useEffect} from 'react'
import { BrowserRouter as Router, Route, Routes , Link } from 'react-router-dom';
import axios from "axios";
function Product() {
  const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    useEffect(() => {
      // Make GET request to fetch data
      //  .get("https://jsonplaceholder.typicode.com/posts")
      axios
          .get("https://localhost:7115/ProductCategories")
          .then((response) => {
            console.log(response)
              setData(response.data);
              console.log(data)
              setLoading(false);
          })
          .catch((err) => {
              setError(err.message);
              setLoading(false);
          });

          //delete
           //deletedata()
  }, []);
 
  const deletedata = async(id=0)=>{
    console.log(id)
    if(id>0)
    {
    await axios
    .delete("https://localhost:7115/ProductCategories/"+id)
    .then((response) => {
      console.log(response)
        setData(response.data);
        console.log(data)
        setLoading(false);
    })
    .catch((err) => {
        setError(err.message);
        setLoading(false);
    });
  }
    }
  // const handelDelete = async (id) => {

  //   console.log("id : -", id);
  //   setLoading(true);
  //   try {
  //     const response = await fetch("https://localhost:7115/ProductCategories/" + id, {
  //       method: "DELETE",
  //     });
  //     if (!response.ok) {
  //       throw new Error("Failed to delete item");
  //     }
  //    // setUser(user.filter((item) => item.id !== id));
  //   } catch (error) {
  //     setError(error.message);
  //   } finally {
  //     setLoading(false);
  //   }
  // };

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;
  return (
    <div>
        <table>
          <thead>
            <tr>
              <td>Id</td>
              <td>Name</td>
              <td>...</td>
            </tr>
          </thead>
          <tbody>
          {data.map((r) => (
                   <tr>
                   <td key={r.productCategoryID}>{r.productCategoryID}</td>
                   <td>{r.name}</td>
                   <td>
                    {/* <button >Edit</button> */}
                    <Link to={`/editcate/${r.productCategoryID}`}>
                     Edit
                    </Link>
                    {/* <button onClick={() => handelDelete(r.productCategoryID)}>Delete</button> */}
                    <button onClick={() => deletedata(r.productCategoryID)}>Delete</button>
                   </td>
                 </tr>
                ))}
 
          </tbody>
        </table>
    </div>
  )
}

export default Product
