import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    keepView: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    addKeep(state, newKeep) {
      state.keeps.push(newKeep)
    },
    setKeepView(state, keep) {
      state.keepView = keep
    }
  },
  actions: {

    // Auth
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => { console.log('Login Failed', e) })
    },
    logout({ commit }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
        .catch(e => {
          console.log('Logout Failed')
        })
    },

    // Keeps
    getPublicKeeps({ commit }) {
      api.get('keeps')
        .then(res => { commit('setKeeps', res.data) })
        .catch(e => { console.log('Unable to get Keeps', e) })
    },
    addKeep({ commit }, newKeep) {
      api.post('keeps', newKeep)
        .then(res => commit('addKeep', newKeep))
        .catch(e => { console.log('Unable to add Keep', e) })
    },
    getKeep({ commit }, id) {
      api.get('keeps/' + id)
        .then(res => {
          commit('setKeepView', res.data)
          router.push({ name: 'keep', params: { id: id } })
        })
        .catch(e => { console.log('Unable to add Keep', e) })
    }
  }
})