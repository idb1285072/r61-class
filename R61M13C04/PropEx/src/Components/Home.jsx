import React from 'react'

function Home(props) {
    const{title,des}=props
  return (
    <div>
      {/* <h1>
        {props.title}

      </h1>
      <p>
        {props.des}
      </p> */}
      <div>
        <h2>Array destructuring</h2>
        <h1>
        {title}

      </h1>
      <p>
        {des}
      </p>
      </div>
    </div>
  )
}

export default Home
