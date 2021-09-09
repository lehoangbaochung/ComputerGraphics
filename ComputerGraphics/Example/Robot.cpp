#include <GL/glut.h>
#include <windows.h>
#include <math.h>
#define M_PI 3.14159265358979323846

#define TORSO_HEIGHT 5.0
#define TORSO_RADIUS 1.2

#define HEAD_HEIGHT 1.7
#define HEAD_RADIUS 1.3

#define UPPER_ARM_HEIGHT 3.0
#define LOWER_ARM_HEIGHT 2.0

#define UPPER_ARM_RADIUS  0.65
#define LOWER_ARM_RADIUS  0.5

#define LOWER_LEG_HEIGHT 3.0
#define UPPER_LEG_HEIGHT 3.0

#define UPPER_LEG_RADIUS  0.65
#define LOWER_LEG_RADIUS  0.5

#define SHOULDER_RADIUS 0.85
#define JOINT_RADIUS 0.85

static GLfloat theta[11] = { 0.0,0.0,0.0,0,0.0,0.0,0.0,
            180.0,0.0,180.0,0.0 }; /* initial joint angles */

GLfloat theta_min[11];
GLfloat theta_max[11];
GLfloat theta_freq[11];
GLfloat knees_y, knees_z;
GLfloat mat_x, mat_y, mat_z, p = 0.0, q = 0.0;

GLint reflect = 1, beginx = 0, beginy = 0, moving = 0;
GLUquadricObj* t, * gl, * h, * lua, * lla, * rua, * rla, * lll, * rll, * rul, * lul;

double size = 1.0;
void torso() // thân 
{
    glPushMatrix();
    glColor3f(1.0, 1.0, 0.0);
    glRotatef(-90.0, 1.0, 0.0, 0.0);
    gluCylinder(t, TORSO_RADIUS, TORSO_RADIUS * 1.5, TORSO_HEIGHT, 10, 10);
    glPopMatrix();
}

void head() // đầu 
{
    glPushMatrix();
    glColor3f(1.0, 1.0, 0.0);
    glTranslatef(0.0, 0.5 * HEAD_HEIGHT, 0.0);
    glScalef(HEAD_RADIUS, HEAD_HEIGHT, HEAD_RADIUS);
    gluSphere(h, 1.0, 10, 10);
    glPopMatrix();
}

void glass_bot() // kính mắt 
{
    glPushMatrix();
    glTranslatef(0.0, 0.5 * HEAD_HEIGHT, 0.075);
    glRotatef(-90.0, 1.0, 0.0, 0.0);
    gluCylinder(gl, HEAD_RADIUS, HEAD_RADIUS, HEAD_HEIGHT / 2, 10, 10);
    glPopMatrix();
}

void elbow_joints() // khớp khủy tay
{
    glPushMatrix();
    glScalef(SHOULDER_RADIUS / 1.2, SHOULDER_RADIUS / 1.2, SHOULDER_RADIUS / 1.2);
    gluSphere(h, 1.0, 10, 10);
    glPopMatrix();
}

void palms() // lòng bàn tay 
{
    glPushMatrix();
    glScalef(SHOULDER_RADIUS / 1.3, SHOULDER_RADIUS / 1.3, SHOULDER_RADIUS / 1.3);
    gluSphere(h, 1.0, 10, 10);
    glPopMatrix();
}

void knee_joints() // đầu gối 
{
    glPushMatrix();
    glScalef(JOINT_RADIUS, JOINT_RADIUS, JOINT_RADIUS);
    gluSphere(h, 1.0, 10, 10);
    glPopMatrix();
}

void torso_disk()// đĩa thân
{
    glPushMatrix();
    glScalef(1.5 * TORSO_RADIUS, 0.1, 1.5 * TORSO_RADIUS);
    gluSphere(h, 1.0, 10, 10);
    glPopMatrix();
}

// thiết lập chiếu sáng
void initLighting() {
    GLfloat mat_diffuse[] = { 1.0, 1.0, 0.0, 1.0 };
    GLfloat mat_ambient[] = { 1.0, 1.0, 0.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { 1.0, 1.0, 1.0, 0.0 }; // điểm chiếu sáng
    glClearColor(0.0, 0.0, 0.0, 0.0);
    glShadeModel(GL_SMOOTH);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat_diffuse);
    glMaterialfv(GL_FRONT, GL_AMBIENT, mat_ambient);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_LIGHTING);// lenh kich hoat nguon sang
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}

void left_upper_arm() // vẽ bắp tay trái
{
    glPushMatrix();
    gluCylinder(lua, UPPER_ARM_RADIUS * 1.2, UPPER_ARM_RADIUS, UPPER_ARM_HEIGHT, 10, 10);
    glPopMatrix();
}

void left_lower_arm() //tay dươí  trái
{
    glPushMatrix();
    gluCylinder(lla, LOWER_ARM_RADIUS * 1.1, LOWER_ARM_RADIUS, LOWER_ARM_HEIGHT, 10, 10);
    glPopMatrix();
}

void right_upper_arm() // vẽ bắp tay phải
{
    glPushMatrix();
    glRotatef(-90.0, 1.0, 0.0, 0.0);
    gluCylinder(rua, UPPER_ARM_RADIUS * 1.2, UPPER_ARM_RADIUS, UPPER_ARM_HEIGHT, 10, 10);
    glPopMatrix();
}

void right_lower_arm()// tay dưới phải
{
    glPushMatrix();
    glRotatef(-90.0, 1.0, 0.0, 0.0);
    gluCylinder(rla, LOWER_ARM_RADIUS * 1.1, LOWER_ARM_RADIUS, LOWER_ARM_HEIGHT, 10, 10);
    glPopMatrix();
}

void left_upper_leg() //chân trên trái
{
    glPushMatrix();
    glRotatef(-120.0, 1.0, 0.0, 0.0);
    gluCylinder(lul, UPPER_LEG_RADIUS * 1.2, UPPER_LEG_RADIUS, UPPER_LEG_HEIGHT, 10, 10);
    glPopMatrix();
}

void left_lower_leg() //chân dưới trái
{
    glPushMatrix();
    glTranslatef(0.0, -0.25, -UPPER_LEG_HEIGHT / 2);
    glRotatef(-70.0, 1.0, 0.0, 0.0);
    gluCylinder(lll, LOWER_LEG_RADIUS, LOWER_LEG_RADIUS * 1.5, LOWER_LEG_HEIGHT, 10, 10);
    glPopMatrix();
}

void right_upper_leg() // chân phải trên 
{
    glPushMatrix();
    glRotatef(-120.0, 1.0, 0.0, 0.0);
    gluCylinder(rul, UPPER_LEG_RADIUS * 1.2, UPPER_LEG_RADIUS, UPPER_LEG_HEIGHT, 10, 10);
    glPopMatrix();
}

void right_lower_leg() //chân phải dưới 
{
    glPushMatrix();
    glColor3f(1.0, 1.0, 0.0);
    glTranslatef(0.0, -0.25, -UPPER_LEG_HEIGHT / 2);
    glRotatef(-70.0, 1.0, 0.0, 0.0);
    gluCylinder(rll, LOWER_LEG_RADIUS, LOWER_LEG_RADIUS * 1.5, LOWER_LEG_HEIGHT, 10, 10);
    glPopMatrix();
}

void drawFloor()
{
    glDisable(GL_LIGHTING);
    glBegin(GL_QUADS);
    glVertex3f(-20, -10, 20);
    glVertex3f(20, -10, 20);
    glVertex3f(20, -10, -20);
    glVertex3f(-20, -10, -20);
    glEnd();
    glEnable(GL_LIGHTING);
}

void drawrobot() {
    torso(); // vẽ thân

    // bđ vẽ đầu 
    glPushMatrix();
    glTranslatef(0.0, TORSO_HEIGHT + 0.5 * HEAD_HEIGHT, 0.0);
    glRotatef(theta[2], 0.0, 1.0, 0.0);
    glTranslatef(0.0, -0.5 * HEAD_HEIGHT, 0.0);
    head();
    glass_bot();
    glPopMatrix();
    // kết vẽ đầu

    //right arm

    // bắt đầu tay trái
    glPushMatrix();
    glTranslatef(-(TORSO_RADIUS + UPPER_ARM_RADIUS), 0.9 * TORSO_HEIGHT, 0.0);
    glRotatef(theta[3], 1.0, 0, 0.0);
    left_upper_arm();

    //glTranslatef(0.0, UPPER_ARM_HEIGHT, 0.0);
    glTranslatef(0.0, 0.0, UPPER_ARM_HEIGHT);
    elbow_joints();
    glRotatef(theta[4], 1.0, 0.0, 0.0);
    left_lower_arm();
    glTranslatef(0.0, 0.0, LOWER_ARM_HEIGHT);
    palms();
    glPopMatrix();
    // kết  tay trái
    //tay phải
    glPushMatrix();
    glTranslatef(TORSO_RADIUS + UPPER_ARM_RADIUS, 0.9 * TORSO_HEIGHT, 0.0);
    glRotatef(theta[5], 1.0, 0.0, 0.0);
    right_upper_arm();
    glTranslatef(0.0, UPPER_ARM_HEIGHT, 0.0);
    elbow_joints();
    right_lower_arm();
    glTranslatef(0.0, LOWER_ARM_HEIGHT, 0.0);
    palms(); // tay phải dưới

    glPopMatrix();

    glPushMatrix();
    glTranslatef(0.0, TORSO_HEIGHT, 0.0);
    torso_disk();
    glPopMatrix();

    //bắt đầu chân trái
    glPushMatrix();
    glTranslatef(-(TORSO_RADIUS), 0.1 * UPPER_LEG_HEIGHT, 0.0);
    glRotatef(theta[7], 1.0, 0.0, 0.0);
    left_upper_leg();

    glTranslatef(0.0, UPPER_LEG_HEIGHT, -1.5);
    knee_joints();
    glTranslatef(0.0, 0.0, 1.5);

    left_lower_leg();
    glPopMatrix();// kết chân trái
    // bắt đầu chân phải
    glPushMatrix();
    glTranslatef((TORSO_RADIUS), 0.1 * UPPER_LEG_HEIGHT, 0.0);
    glRotatef(theta[9], 1.0, 0.0, 0.0);
    right_upper_leg();

    glTranslatef(0.0, UPPER_LEG_HEIGHT, -1.5);
    knee_joints();
    glTranslatef(0.0, 0.0, 1.5);

    right_lower_leg();
    glPopMatrix();
    // chân phải dưới
}

void drawreflection() {
    // tắt chế độ hiển thị màu và độ sâu
    glDisable(GL_DEPTH_TEST);
    glDisable(GL_COLOR);
    //bật chế độ vẽ vào bộ đệm stencil. 
    glEnable(GL_STENCIL_TEST);
    // cho phép thay thế đối tượng
    glStencilOp(GL_REPLACE, GL_REPLACE, GL_REPLACE);
    glStencilFunc(GL_ALWAYS, 1, 1);

    //Bây giờ vẽ sàn chỉ cần gắn thẻ pixel của sàn là giá trị stencil 1.
    drawFloor();

    //Bật lại cập nhật màu sắc và độ sâu.
    glEnable(GL_COLOR);
    glEnable(GL_DEPTH_TEST);

    //giữ lại các đối tượng, hiệu ứng được thêm bổ sung
    glStencilFunc(GL_EQUAL, 1, 1);
    glStencilOp(GL_KEEP, GL_KEEP, GL_KEEP);

    //Vẽ rubik phản chiếu, nhưng chỉ nơi sàn.
    glPushMatrix();
    glTranslatef(0, -15, 0);
    glScalef(1.0, -1.0, 1.0);
    drawrobot();
    glPopMatrix();

    glDisable(GL_STENCIL_TEST);

    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
    glColor4f(1, 1, 1, 0.2);
    drawFloor();
    glDisable(GL_BLEND);
}

void display(void)
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
    glLoadIdentity();

    gluLookAt(0.0, 0.0, 60, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
    // đổi màu robot
    glColor3f(1.0, 1.0, 1.0);
    glTranslatef(0.0, 0.0, 10);

    glTranslatef(0.0, -3.0, 0.0);
    glRotatef(theta[0], 0.0, 1.0, 0.0);
    glRotatef(p, 1.0, 0.0, 0.0);
    glRotatef(q, 0.0, 1.0, 0.0);
    if (reflect == 1)
        drawreflection();
    drawrobot();
    glFlush();
    glutSwapBuffers();
}

float getAngle(float freq, float min, float max, float b) {
    return (max - min) * sin(freq * M_PI * b) + 0.5 * (min + max);
}

float taytrai = 0;
float tayphai = 0;
float chantrai = 0;
float chanphai = 0;

static void idle(void) {
    glutPostRedisplay();
}
// thiết lập chế độ nhìn 
void myReshape(int w, int h)
{
    glViewport(0, 0, w, h);
    float ratio = (float)w / (float)h;
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(45.0, ratio, 1.0, 450);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();

}
void keyboard(unsigned char key, int x, int y)
{
    switch (key) {
    case 'a':

        theta[3] = getAngle(theta_freq[3], theta_min[3], theta_max[3], taytrai);
        taytrai += 0.005;


        break;
    case 'z':

        theta[3] = getAngle(theta_freq[3], theta_min[3], theta_max[3], taytrai);
        taytrai -= 0.005;

        break;
    case 's':

        theta[7] = getAngle(theta_freq[7], theta_min[7], theta_max[7], chantrai);
        chantrai += 0.005;

        break;
    case 'x':

        theta[7] = getAngle(theta_freq[7], theta_min[7], theta_max[7], chantrai);
        chantrai -= 0.005;

        break;
    case 'd':

        theta[9] = getAngle(theta_freq[9], theta_min[9], theta_max[9], chanphai);        chanphai += 0.005;

        break;
    case 'c':

        theta[9] = getAngle(theta_freq[9], theta_min[9], theta_max[9], chanphai);        chanphai -= 0.005;

        break;
    case 'f':

        theta[5] = getAngle(theta_freq[5], theta_min[5], theta_max[5], tayphai);
        tayphai += 0.005;

        break;
    case 'v':

        theta[5] = getAngle(theta_freq[5], theta_min[5], theta_max[5], tayphai);
        tayphai -= 0.005;

        break;
    case 't':

        theta[9] = getAngle(theta_freq[9], theta_min[9], theta_max[9], chanphai);        chanphai -= 0.009;
        theta[7] = getAngle(theta_freq[7], theta_min[7], theta_max[7], chantrai);        chantrai -= 0.009;
        theta[5] = getAngle(theta_freq[5], theta_min[5], theta_max[5], tayphai);
        tayphai += 0.01;
        theta[3] = getAngle(theta_freq[5], theta_min[5], theta_max[5], taytrai);

        taytrai += 0.01;

        break;

    }
    glutPostRedisplay();
}

void myinit()
{
    initLighting();
    glShadeModel(GL_SMOOTH);

    glEnable(GL_DEPTH_TEST);

    glClearColor(0.0, 0.0, 0.0, 1.0);
    glColor3f(0.0, 0.0, 0.0);

    theta_freq[1] = 3.0;
    theta_max[1] = 15.0; theta_min[1] = -5.0;

    theta_freq[3] = 3.0; theta_freq[5] = 3.0;
    theta_max[3] = -90.0; theta_max[5] = 90.0;

    theta_freq[4] = 2.0; theta_freq[6] = 2.0;
    theta_max[4] = -35.0; theta_max[6] = -35.0;
    theta_min[4] = -10.0; theta_min[6] = -10.0;

    theta_freq[7] = 3.0; theta_freq[9] = 3.0;

    theta_max[7] = 200.0; theta_max[9] = 160.0;
    theta_min[7] = 160.0; theta_min[9] = 200.0;

    theta_min[0] = -30; theta_freq[0] = 0.5;
    theta_max[0] = 30;

    h = gluNewQuadric();

    t = gluNewQuadric();

    gl = gluNewQuadric();

    lua = gluNewQuadric();

    lla = gluNewQuadric();

    rua = gluNewQuadric();

    rla = gluNewQuadric();

    lul = gluNewQuadric();

    lll = gluNewQuadric();

    rul = gluNewQuadric();

    rll = gluNewQuadric();
}

void motion(int x, int y)
{
    if (moving)
    {
        q = q + (x - beginx);
        beginx = x;
        p = p + (y - beginy);
        beginy = y;
        glutPostRedisplay();
    }
}

void mouse(int btn, int state, int x, int y)
{
    if (btn == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
    {
        moving = 1;
        beginx = x;
        beginy = y;
    }
}

int main(int argc, char** argv)
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(500, 500);
    glutCreateWindow("robot");
    myinit();
    glutReshapeFunc(myReshape);
    glutDisplayFunc(display);
    glutIdleFunc(idle);
    glutMouseFunc(mouse);
    glutMotionFunc(motion);
    glutKeyboardFunc(keyboard);
    glutMainLoop();
    return 0;
}
