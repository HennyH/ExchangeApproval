import m from 'mithril';
import {LoginModalContent} from '../Modal/ModalContents'
import Modal from '../Modal/Modal'
import Layout from 'Components/Layout'

window.isLoggedIn = false;

function onSubmitLogin() {
	window.isLoggedIn = true;
	m.route.set("/student-office");
}

export default function Login() {
	function view() {
		return (
			<Layout>	
				<Modal size = {"lg"}>
					<LoginModalContent onSubmit= {onSubmitLogin}/>
				</Modal>
			</Layout>
		);
	}
	return {view};
}