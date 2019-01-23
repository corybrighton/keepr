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
    keepView: {},
    vaults: [],
    vaultView: {}
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
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultView(state, vault) {
      state.vaultView = vault
    }

  },
  actions: {

    // Auth
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => { console.log('Login Failed', e) })
    },
    logout({ commit }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
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
    getKeep({ commit, dispatch }, id) {
      commit('setKeepView', {})
      api.get('keeps/' + id)
        .then(res => {
          commit('setKeepView', res.data)
          dispatch('getPublicKeeps')
        })
        .catch(e => { console.log('Unable to add Keep', e) })
    },

    // Vaults
    getVaults({ commit }) {
      api.get('vaults/')
        .then(res => {
          commit('setVaults', res.data)
        })
        .catch(e => { console.log('Unable to get Vaults', e) })
    },
    getVault({ commit }, id) {
      api.get('vaults/' + id)
        .then(res => {
          commit('setVaultView', res.data)
          router.push({ name: 'vault', params: { id: id } })
        })
        .catch(e => { console.log('Unable to get Vault', e) })
    },
    addToVault({ commit, dispatch }, vaultkeep) {
      console.log(vaultkeep)
      api.post('vaults/' + vaultkeep.vaultId)
        .then(res => dispatch('getPublicKeeps'))
        .catch(e => { console.log('Unable to add keep to vault', e) })
    }
  }
})