import { useEffect, useState } from "react"
import { Link } from "react-router-dom";

export function Product(){

    const [product , setProduct] = useState([])
    function GetProduct(){
        fetch('https://localhost:7115/ProductCategories')
        .then(res =>{
            if(res.ok){
                return res.json()
            }
            throw new Error("error");
            
        })
        .then(data =>{
            setProduct(data)
        })
    }

    useEffect(GetProduct, [])

    console.log("product" , product);
    //console.log("setProduct" , setProduct);

    function deleteProduct(id, name){

        const conf = confirm(`Do you want to delete ${name}`)
        if(conf){
            console.log('di ' , id)
        fetch('https://localhost:7115/ProductCategories/'+ id, {
            method : "DELETE"
        })
        .then(res =>{
            if (!res.ok) {
                throw new Error("reepor");
                
            }
            GetProduct()
            alert(`${name} Deleted Successfully`)
        })
        }
        
    }
    

    return (
        <>
        <h2>Product_list</h2>

        <table>
            <thead>
                <tr>
                    <th>Product With Catagory</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {
                    product.map((p , i)=>{
                        return (
                            <tr key={i}>
                                <td>
                                    Category Name : {p.name}
                                    {
                                        p.products.length> 0 ? (
                                            <table>
                                            <thead>
                                                <tr>
                                                    <th>productID</th>
                                                    <th>name</th>
                                                    <th>color</th>
                                                    <th>productNumber</th>
                                                    <th>listPrice</th>
                                                    <th>size</th>
                                                    <th>standardCost</th>
                                                    <th>weight</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {
                                                    p.products.map((v , o) =>{
                                                        return (
                                                            <tr key={o}>
                                                                <td>{v.productID}</td>
                                                                <td>{v.name}</td>
                                                                <td>{v.color}</td>
                                                                <td>{v.productNumber}</td>
                                                                <td>{v.listPrice}</td>
                                                                <td>{v.size}</td>
                                                                <td>{v.standardCost}</td>
                                                                <td>{v.weight}</td>
                                                            </tr>
                                                        )
                                                    })
                                                }
                                            </tbody>
                                             </table>
                                        ) : (
                                            <p> No product</p>
                                        )
                                    }
                                    

                                </td>
                                <td>
                                    
                                    <Link to={`/editproduct/${p.productCategoryID}`}>Edit Product</Link>
                                    <button onClick={() =>deleteProduct(p.productCategoryID, p.name)}>Delete</button>
                                </td>
                            </tr>
                        )
                    })
                }
            </tbody>
        </table>
        </>

        


    )
}