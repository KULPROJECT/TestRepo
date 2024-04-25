import { Route, Routes } from 'react-router-dom';
import LoginForm from './Components/LoginForm/LoginForm';
import CreateUser from './Components/CreateUser/CreateUser';
import HomePage from './Components/HomePage/HomePage';


function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginForm />} />
                <Route path="/createuser" element={<CreateUser />} />
            </Routes>
        </>
    )
}
export default App;