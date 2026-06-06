import React, { useState } from "react";
 

const Contact = () => {
    const [title] = useState("Practical React Enterprise");
    const handleAlert = () => {
        alert("I'm a button!");
        };
  return (
    <div>
       
        <h1>Contact Us </h1>
        <p>01444778965</p>
{title}
        <div>
        <button
style={{
color: "#ffff",
height: "5rem",
width: "10rem",
backgroundColor: "tomato",
borderRadius: "5px",
fontSize: "18px",
}}
onClick={handleAlert}
>
Click me
</button>
        </div>
    </div>
  )
}
export default Contact
