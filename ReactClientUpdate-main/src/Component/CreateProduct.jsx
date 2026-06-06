import { useState } from "react";

export const Create = () => {

  const [category, setCategory] = useState({
    name: "",
    products: [],
  });

  const [newProduct, setNewProduct] = useState({
    color: "",
    listPrice: 0,
    name: "",
    productNumber: "",
    size: 0,
    standardCost: 0,
    weight: 0,
  });

  
  const addProduct = () => {
    if (!newProduct.name || !newProduct.productNumber) {
      alert("Please fill out all required product fields.");
      return;
    }
    setCategory({
      ...category,
      products: [...category.products, newProduct],
    });
    setNewProduct({
      color: "",
      listPrice: 0,
      name: "",
      productNumber: "",
      size: 0,
      standardCost: 0,
      weight: 0,
    });
  };

  
  const handleCategoryChange = (e) => {
    setCategory({
      ...category,
      [e.target.name]: e.target.value,
    });
  };
  
  const handleNewProductChange = (e) => {
    const { name, value } = e.target;
    setNewProduct({
      ...newProduct,
      [name]: value,
    });
  };

  const createCategory = (e) => {
    e.preventDefault();
    if (!category.name || category.products.some(p => !p.name || !p.productNumber)) {
      alert("Please fill out all required fields.");
      return;
    }
    
    fetch("https://localhost:7115/ProductCategories", {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(category),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        alert("Category created successfully");
        clearAll();
      })
      .catch((error) => {
        alert("Error creating category: " + error.message);
      });
  };

  
  const clearAll = () => {
    setCategory({
      name: "",
      products: [],
    });
    setNewProduct({
      color: "",
      listPrice: 0,
      name: "",
      productNumber: "",
      size: 0,
      standardCost: 0,
      weight: 0,
    });
  };


    function editPro(o){
        const product = category.products[o];
        setNewProduct(product);
        delPro(o);
    }

    function delPro(o){
        const updatep = category.products.filter((_, i)=> i !== o);
        setCategory({
            ...category,
            products : updatep
        })
    }


  return (
    <>
      <div>
        <h1>Create Product</h1>
        <form onSubmit={createCategory}>
         
              <label htmlFor="categoryName">Category Name</label>
              <input type="text" name="name" id="categoryName" value={category.name} onChange={handleCategoryChange}/>
         
          <h2>Add New Product</h2>
         
                <label htmlFor="newProductName">Product Name</label>
                <input type="text" id="newProductName" name="name" value={newProduct.name} onChange={handleNewProductChange} />
            

            
                <label htmlFor="newProductNumber">Product Number</label>
                <input type="text" id="newProductNumber" name="productNumber" value={newProduct.productNumber} onChange={handleNewProductChange}/>
             

              
                <label htmlFor="newColor">Color</label>
                <input type="text" id="newColor" name="color" value={newProduct.color} onChange={handleNewProductChange}/>
              

              
                <label htmlFor="newListPrice">List Price</label>
                <input type="number" id="newListPrice" name="listPrice" value={newProduct.listPrice} onChange={handleNewProductChange}/>
          
                <label htmlFor="newWeight">Weight</label>
                <input type="number" id="newWeight" name="weight" value={newProduct.weight} onChange={handleNewProductChange}/>
             
                <label htmlFor="newStandardCost">Standard Cost</label>
                <input type="number" id="newStandardCost" name="standardCost" value={newProduct.standardCost} onChange={handleNewProductChange}/>
             
                <label htmlFor="newSize">Size</label>
                <input type="number" id="newSize" name="size" value={newProduct.size} onChange={handleNewProductChange} />
             

            <button  type="button"  onClick={addProduct}> Add Product </button>
          

           

         

          {
            category.products.length> 0 ? (
                <div>
                <table>
                <thead>
                    <tr>
                        <th>Serial</th>
                        <th>name</th>
                        <th>color</th>
                        <th>productNumber</th>
                        <th>listPrice</th>
                        <th>size</th>
                        <th>standardCost</th>
                        <th>weight</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        category.products.map((v,o)=>{
                            return (
                                <tr key={o}>
                                    <td>{o+1}</td>
                                    <td>{v.name}</td>
                                    <td>{v.color}</td>
                                    <td>{v.productNumber}</td>
                                    <td>{v.listPrice}</td>
                                    <td>{v.size}</td>
                                    <td>{v.standardCost}</td>
                                    <td>{v.weight}</td>
                                    <td>
                                        <button onClick={()=>editPro(o)}>Edit</button>
                                        <button onClick={()=>delPro(o)}>Delete</button>
                                    </td>
                                </tr>
                            )
                        })
                    }
                </tbody>
              </table>
              <button type="submit">Create Category and Products  </button>
              </div>

            ) : (
                <p>Must add product to show list</p>
            )
          }


         
          

          
        </form>
      </div>
    </>
  );
};

                   
