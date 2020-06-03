<?php
namespace App\Controller;

use App\Controller\AppController;

/**
 * Rollballranking Controller
 *
 * @property \App\Model\Table\RollballrankingTable $Rollballranking
 *
 * @method \App\Model\Entity\Rollballranking[]|\Cake\Datasource\ResultSetInterface paginate($object = null, array $settings = [])
 */
class RollballrankingController extends AppController
{

    /**
     * Index method
     *
     * @return \Cake\Http\Response|void
     */
    public function index()
    {
        $rollballranking = $this->paginate($this->Rollballranking);

        $this->set(compact('rollballranking'));
    }

    /**
     * View method
     *
     * @param string|null $id Rollballranking id.
     * @return \Cake\Http\Response|void
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function view($id = null)
    {
        $rollballranking = $this->Rollballranking->get($id, [
            'contain' => []
        ]);

        $this->set('rollballranking', $rollballranking);
    }

    /**
     * Add method
     *
     * @return \Cake\Http\Response|null Redirects on successful add, renders view otherwise.
     */
    public function add()
    {
        $rollballranking = $this->Rollballranking->newEntity();
        if ($this->request->is('post')) {
            $rollballranking = $this->Rollballranking->patchEntity($rollballranking, $this->request->getData());
            if ($this->Rollballranking->save($rollballranking)) {
                $this->Flash->success(__('The rollballranking has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The rollballranking could not be saved. Please, try again.'));
        }
        $this->set(compact('rollballranking'));
    }

    /**
     * Edit method
     *
     * @param string|null $id Rollballranking id.
     * @return \Cake\Http\Response|null Redirects on successful edit, renders view otherwise.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function edit($id = null)
    {
        $rollballranking = $this->Rollballranking->get($id, [
            'contain' => []
        ]);
        if ($this->request->is(['patch', 'post', 'put'])) {
            $rollballranking = $this->Rollballranking->patchEntity($rollballranking, $this->request->getData());
            if ($this->Rollballranking->save($rollballranking)) {
                $this->Flash->success(__('The rollballranking has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The rollballranking could not be saved. Please, try again.'));
        }
        $this->set(compact('rollballranking'));
    }

    /**
     * Delete method
     *
     * @param string|null $id Rollballranking id.
     * @return \Cake\Http\Response|null Redirects to index.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function delete($id = null)
    {
        $this->request->allowMethod(['post', 'delete']);
        $rollballranking = $this->Rollballranking->get($id);
        if ($this->Rollballranking->delete($rollballranking)) {
            $this->Flash->success(__('The rollballranking has been deleted.'));
        } else {
            $this->Flash->error(__('The rollballranking could not be deleted. Please, try again.'));
        }

        return $this->redirect(['action' => 'index']);
    }

    public function getRanking()
    {
        error_log("getRanking()");
        $this->autoRender = false;

        $rank = $this->request->getData("Rank");
        $query = $this->Rollballranking->find('all');

        $json_array = json_encode($query);
        echo $json_array;
    }

    public function updateRanking()
    {
        $this->autoRender = false;

        $rollballRankingTable = $this->getTableLocator()->get('rollballranking');

        $id = 0;
        if (isset($this->request->data['id']))
            $id = $this->request->data['id'];
        if (isset($this->request->data['name']))
            $name = $this->request->data['name'];
        if (isset($this->request->data['time']))
            $time = $this->request->data['time'];

        if($id != 0)
        {
            $tarrgetRecord = $rollballRankingTable->get($id);
            $tarrgetRecord->Name = $name;
            $tarrgetRecord->Time = $time;

            if($rollballRankingTable->save($tarrgetRecord))
            {
                echo 1;
            }
            else
            {
                echo 0;
            }
        }
        else
            echo 2;

    }
}
