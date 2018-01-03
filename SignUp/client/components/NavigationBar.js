import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import propTypes from "prop-types";
import { logout } from "../actions/authActions";

class NavigationBar extends React.Component {
  logout(e) {
    e.preventDefault();
    this.props.logout();
  }

  render() {
    const { isAuthenticated } = this.props.auth;

    const userLinks = (
      <ul className="navbar-nav navbar-right">
          <li className="nav-item">
            <a href="#" className="nav-link" onClick={this.logout.bind(this)}>Logout</a>
          </li>
      </ul>
    );

    const guestLinks = (
      <ul className="navbar-nav navbar-right">
          <li className="nav-item">
            <Link to="/signup" className="nav-link">Sign Up</Link>
          </li>
          <li className="nav-item">
            <Link to="/login" className="nav-link">Login</Link>
          </li>
      </ul>
    );

    return(
      <nav className="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
          <a className="navbar-brand" href="/">PhRemit</a>
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarsExampleDefault">
              <ul className="navbar-nav mr-auto">
                  <li className="nav-item"><Link to="/home" className="nav-link">Home</Link></li>
              </ul>
              { isAuthenticated ? userLinks : guestLinks }
          </div>
      </nav>
    )
  }
}

NavigationBar.propTypes = {
  auth: propTypes.object.isRequired,
  logout: propTypes.func.isRequired
}

function mapStateToProps(state) {
  return {
    auth: state.auth
  }
}

export default connect(mapStateToProps, { logout })(NavigationBar);
