import { connect } from 'react-redux';
import TaskDisplay from "./TaskDisplay";
import { fetchTaskStart} from "../../store";

const mapStateToProps = state => (
    {
        tasks: state.tasks || []
    }
);

const mapDispathcToProps = ({
    onLoad: fetchTaskStart
});

export default connect(mapStateToProps, mapDispathcToProps)(TaskDisplay);