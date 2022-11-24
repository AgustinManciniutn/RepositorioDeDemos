import React from 'react'
import reactlogo from './Images/react logo.png'

export default function Header() {

    return (

        <nav class="navbar navbar-light bg-light px-5">
            <a class="navbar-brand px-5" href="#">
                <img src={reactlogo}  width="30" height="30" alt="" /> &nbsp; React Demo
            </a>
        </nav>
        
        
        )



}
