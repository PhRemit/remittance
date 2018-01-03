import React from "react";
import { connect } from "react-redux";
import { createEvent } from "../../actions/eventActions"
import TextFieldGroup from "../common/TextFieldGroup";
import propTypes from "prop-types"

class EventForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      title: "",
      errors: {},
      isLoading: false
    };

    this.onSubmit = this.onSubmit.bind(this);
    this.onChange = this.onChange.bind(this);
  }

  onSubmit(e){
    e.preventDefault();
    this.props.createEvent(this.state);
  }

  onChange(e) {
    this.setState({ [e.target.name]: e.target.value });
  }

  render() {
    const { title, errors, isLoading } = this.state;

    return (
      <form onSubmit={this.onSubmit}>
        <h1>Create New Game</h1>

        <TextFieldGroup
          field="title"
          label="Event Title"
          value={title}
          onChange={this.onChange}
          error={errors.title}
        / >

        <div className="form-group">
          <button className="btn btn-primary btn-lg" disabled={isLoading}>
            Create
          </button>
        </div>
      </form>
    )
  }
}

EventForm.propTypes = {
  createEvent: propTypes.func.isRequired
}

export default connect(null, { createEvent })(EventForm);
