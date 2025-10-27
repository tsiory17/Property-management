import React from 'react'
import { Link } from 'react-router-dom'

export const Header = () => {
  return (
    <nav className="navbar navbar-expand-sm navbar-light bg-light border-bottom shadow-sm mb-3">
      <div className="container-fluid">
        <a className="navbar-brand" href="/Tenants/MainPage">
          Manage Property
        </a>
        <div className="navbar collapse collapse d-sm-inline-flex justify content between">
          <ul className="navbar-nav flex-grow-1">
            <li className="nav-item">
              <a className="nav-link"  href="/Tenants/MainPage">Home</a>
            </li>
            <li className="nav-item">
              <Link className="nav-link"  to ="/viewApartments">View Apartments</Link>
            </li>
            <li className="nav-item">
              <a className="nav-link"  href="/Messages/SendMessage">View Messages</a>
            </li>
          </ul>
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <a className="btn btn-primary" href="/Account/logout">
                Logout
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>

  )
}

export default Header