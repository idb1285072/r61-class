import React, { useEffect, useState } from "react";

function UseEffectEx() {
  const [count, setCount] = useState(5);
  useEffect(() => {
    document.title = `Learn React ${count} times`;
  },[count]);
  function incrementCount() {
    setCount((c) => c + 1);
  }

  return (
    <div>
      <h1>useEffect Hook Example</h1>
      <h2>Total clicked {count}</h2>
      {/* <button onClick={()=>setCount((p)=>p+1)}>
        clcik me
      </button> */}
      <button onClick={incrementCount}>clcik me</button>
    </div>
  );
}

export default UseEffectEx;
