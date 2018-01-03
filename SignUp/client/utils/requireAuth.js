import React from "react";
import { connect } from "react-redux";
import propTypes from "prop-types";
import { addFlashMessage } from "../actions/flashMessages";

export default function(ComposedComponent) {
  class Authenticate extends React.Component {
    componentWillMount() {
      if (!this.props.isAuthenticated) {
        this.props.addFlashMessage({
          type: "error",
          text: "You need to login to access this page"
        });
        this.context.router.history.push("/login");
      }
    }

    componentWillUpdate(nextProps) {
      if (!nextProps.isAuthenticated) {
        this.context.router.history.push("/");
      }
    }


    render() {
      return (
        <ComposedComponent {...this.props} />
      );
    }
  }

  Authenticate.propTypes = {
    isAuthenticated: propTypes.bool.isRequired,
    addFlashMessage: propTypes.func.isRequired
  }

  Authenticate.contextTypes = {
    router: propTypes.object.isRequired
  }

  function mapStateToProps(state) {
    return {
      isAuthenticated: state.auth.isAuthenticated
    };
  }

  return connect(mapStateToProps, { addFlashMessage })(Authenticate);
}
